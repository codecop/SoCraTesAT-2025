namespace Lib;

public interface ILanguageModel
{
    Message Prompt(List<Message> messages);
}