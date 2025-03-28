using TMPro;
using UnityEngine;

public class TooltipBox : Singleton<TooltipBox>
{
    [SerializeField] private TMP_Text _label;
    
    private Vector3 _initialPosition;

    protected override void Awake()
    {
        _initialPosition = transform.position;
        base.Awake();
    }

    public void ShowAtPosition(string message, Vector2 position)
    {
        _label.text = message;
        transform.position = position;
    }

    public void Hide()
    {
        transform.position = _initialPosition;
    }
}
