using TMPro;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;

    private void Start()
    {
        UpdateDisplay();
    }

    private void OnEnable()
    {
        PlayerHealth.HealthChanged += UpdateDisplay;
    }
    
    private void OnDisable()
    {
        PlayerHealth.HealthChanged -= UpdateDisplay;
    }

    private void UpdateDisplay()
    {
        PlayerHealth playerHealth = PlayerHealth.Instance;
        _healthText.text = $"{playerHealth.Health}/{playerHealth.StartingHealth}";
    }
}
