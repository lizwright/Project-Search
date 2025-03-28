using TMPro;
using UnityEngine;

public class EnemyIntentDisplay : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _icon;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Tooltip _tooltip;

    public void ShowIntent(EnemyAction action)
    {
        _icon.sprite = action.Icon;
        if (action is AttackAction attackAction)
        {
            _text.text = attackAction.damage.ToString();
        }
        else
        {
            _text.text = string.Empty;
        }
        
        _tooltip.SetMessage(action.Tooltip);
    }

}
