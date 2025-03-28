using UnityEngine;

public class TraitIcon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _icon;
    [SerializeField] private Tooltip _tooltip;

    public void SetTrait(Trait trait)
    {
        _icon.sprite = trait.Icon;
        _tooltip.SetMessage(trait.Tooltip);
    }
}
