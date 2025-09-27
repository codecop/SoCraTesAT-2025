namespace Lib;

public class LanguageModelStub(string answer) : ILanguageModel
{
    public Message Prompt(List<Message> messages)
    {
        return new Message(Role.ASSISTANT, answer);
    }
}