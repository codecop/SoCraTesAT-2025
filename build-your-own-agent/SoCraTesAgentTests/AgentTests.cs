using Lib;

namespace SoCraTesAgent;

public class Tests
{
    [Test]
    public void SimpleConversation()
    {
        IUser user = new UserStub(["Hello"]);
        ILanguageModel languageModel = new LanguageModelStub("Hello, how can I help you?");
        var agentLoop = new AgentLoop(user, languageModel, new ToolCallerStub(""));

        agentLoop.Run();

        var chatProtocol = agentLoop.getChatProtocol();
        Assert.That(chatProtocol, Is.EqualTo(new List<Message>
        {
            new(Role.SYSTEM, "You are an AI with the following tools: <toolcall>ls {0}</toolcall>"),
            new(Role.USER, "Hello"),
            new(Role.ASSISTANT, "Hello, how can I help you?"),
        }));
    }

    [Test]
    public void ToolCall()
    {
        IUser user = new UserStub([
            "List the files in my Home Directory"
        ]);
        ILanguageModel languageModel = new LanguageModelStub("<toolcall>ls ~</toolcall>");
        IToolCaller toolCaller = new ToolCallerStub("text.txt\nExitcode 0");
        var agentLoop = new AgentLoop(user, languageModel, toolCaller);

        agentLoop.Run();

        var chatProtocol = agentLoop.getChatProtocol();
        Assert.That(chatProtocol, Is.EqualTo(new List<Message>
        {
            new(Role.SYSTEM, "You are an AI with the following tools: <toolcall>ls {0}</toolcall>"),
            new(Role.USER, "List the files in my Home Directory"),
            new(Role.ASSISTANT, "<toolcall>ls ~</toolcall>"),
            new(Role.USER, "text.txt\nExitcode 0")
        }));
    }
}

public class UserStub(List<string> messages) : IUser
{
    private int counter;

    public string Input()
    {
        return counter >= messages.Count
            ? string.Empty
            : messages[counter++];
    }
}