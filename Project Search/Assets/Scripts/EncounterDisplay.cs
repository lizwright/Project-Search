using TMPro;
using UnityEngine;

public class EncounterDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _encounterText;

    private void Start()
    {
        UpdateDisplay(0);
    }

    private void OnEnable()
    {
        EncounterManager.EncounterChanged += UpdateDisplay;
    }
    
    private void OnDisable()
    {
        EncounterManager.EncounterChanged -= UpdateDisplay;
    }

    private void UpdateDisplay(int encounter)
    {
        _encounterText.text = $"Battle 1-{encounter + 1}";
    }
}
