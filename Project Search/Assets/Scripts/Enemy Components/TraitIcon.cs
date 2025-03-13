using UnityEngine;

public class TraitIcon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _icon;

    public void SetIcon(Sprite sprite)
    {
        _icon.sprite = sprite;
    }
}
