// See https://aka.ms/new-console-template for more information

using Lib;

var agentLoop = new AgentLoop(
    new ConsoleUser(),
    new LanguageModelStub("<tool-call>ls ~</tool-call>"),
    new ToolCallerStub("test.txt")
);

agentLoop.Run();

var chatProtocol = agentLoop.getChatProtocol();
foreach (var message in chatProtocol)
{
    Console.WriteLine(message.Role + ": " + message.Content);
}

public class ConsoleUser : IUser
{
    public string Input()
    {
        Console.Write("> ");
        return Console.ReadLine()!;
    }
}