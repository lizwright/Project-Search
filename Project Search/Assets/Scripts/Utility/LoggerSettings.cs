using UnityEngine;

[CreateAssetMenu(fileName = "Logger Settings", menuName = "ScriptableObjects/Settings/Logger Settings", order = 100)]
public class LoggerSettings : ScriptableObject
{
    public bool EnableDigitSequenceLogs => _enableDigitSequenceLogs;

   [SerializeField] private bool _enableDigitSequenceLogs;
}
