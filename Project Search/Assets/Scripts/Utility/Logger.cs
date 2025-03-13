using UnityEngine;

public class Logger: Singleton<Logger>
{
    [SerializeField] private LoggerSettings _settings;
    
    public void LogDigitMessage(string message)
    {
        if(_settings.EnableDigitSequenceLogs)
            Debug.Log(message);
    }
}
