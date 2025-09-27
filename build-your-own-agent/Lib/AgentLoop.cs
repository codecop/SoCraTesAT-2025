namespace Lib;

public class AgentLoop(IUser user, ILanguageModel languageModel, IToolCaller toolCaller)
{
    private readonly List<Message> _chatProtocol =
    [
        new(Role.SYSTEM, "You are an AI with the following tools: <toolcall>ls {0}</toolcall>")
    ];

    public List<Message> getChatProtocol()
    {
        return _chatProtocol;
    }

    public void Run()
    {
        while (true)
        {
            var input = user.Input();
            if (string.IsNullOrEmpty(input)) break;
            var message = new Message(Role.USER, input);
            _chatProtocol.Add(message);

            var answer = languageModel.Prompt(_chatProtocol);
            _chatProtocol.Add(answer);

            var toolResult = toolCaller.ParseAndCall(answer.Content);
            if (!string.IsNullOrEmpty(toolResult))
            {
                _chatProtocol.Add(new Message(Role.USER, toolResult));
            }
        }
    }
}