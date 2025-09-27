namespace Lib;

public class ToolCallerStub(string stubResult) : IToolCaller
{
    public string ParseAndCall(string message)
    {
        return stubResult;
    }
}