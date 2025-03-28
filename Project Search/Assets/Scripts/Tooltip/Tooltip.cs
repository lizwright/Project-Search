public class Tooltip : TooltipRequestor
{
    private string _message;
    
    public void SetMessage(string message)
    {
        _message = message;
    }
    protected override string GetMessage()
    {
        return _message;
    }
}
