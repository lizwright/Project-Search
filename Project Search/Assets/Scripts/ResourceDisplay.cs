using UnityEngine;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private bool _allowMultipleShownAtOnce;
    
    [SerializeField] private GameObject _circle;
    [SerializeField] private GameObject _square;
    [SerializeField] private GameObject _triangle;
    [SerializeField] private GameObject _diamond;

    private void Awake()
    {
        HideAllResources();
    }

    private void HideAllResources()
    {
        _circle.SetActive(false);
        _square.SetActive(false);
        _triangle.SetActive(false);
        _diamond.SetActive(false);
    }
    
    public void ShowResource(Resource.Suit resourceSuit)
    {
        if (_allowMultipleShownAtOnce == false)
        {
            HideAllResources();
        }
        
        switch (resourceSuit)
        {
            case Resource.Suit.Circle:
                _circle.SetActive(true);
                break;
            case Resource.Suit.Square:
                _square.SetActive(true);
                break;
            case Resource.Suit.Triangle:
                _triangle.SetActive(true);
                break;
            case Resource.Suit.Diamond:
                _diamond.SetActive(true);
                break;
            default:
                Debug.LogError($"Tried to show Resource: {resourceSuit}, but ResourceDisplay  doesn't know what that is ?!?");
                break;
        }
    }
}
