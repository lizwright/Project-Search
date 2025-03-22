using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelData _level;
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private EncounterManager _encounterManager;
    [SerializeField] private GameObject _winUI;
    [SerializeField] private GameObject _loseUI;
    
    private void Start()
    {
        _winUI.SetActive(false);
        _loseUI.SetActive(false);
        
        _turnManager.EnterOutOfCombat();
        _encounterManager.SetLevel(_level);
        
        StartNextEncounter();
    }

    private void OnEnable()
    {
        PlayerHealth.PlayerDied += ShowLoseGameOver;
    }
    
    private void OnDisable()
    {
        PlayerHealth.PlayerDied -= ShowLoseGameOver;
    }

    public void StartNextEncounter()
    {
        if (_encounterManager.LevelHasNextEncounter() == false)
        {
            ShowWinGameOver();
            return;
        }

        _encounterManager.SpawnNextEncounter();
        
        _turnManager.StartPlayerTurn();

    }

    private void ShowLoseGameOver()
    {
        _loseUI.SetActive(true);
    }
    
    private void ShowWinGameOver()
    {
        _winUI.SetActive(true);
    }

    public void Restart()
    {
        PlayerHealth.Instance.SetHealth(PlayerHealth.Instance.StartingHealth);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Continue()
    {
        PlayerHealth.Instance.SetHealth(PlayerHealth.Instance.StartingHealth);
        _winUI.SetActive(false);
        _loseUI.SetActive(false);
        
        InputManager.EnableGameInput();

    }
    
}
