using UnityEngine;

public class DigitSlot : MonoBehaviour, IDraggableReceiver
{
    [SerializeField] private GameObject _hidePanel;
    [SerializeField] private ResourceDisplay _hiddenResourceDisplay;
    [SerializeField] private ResourceDisplay _guessedResourceDisplay;
    
    public Resource.Suit ResourceToGuess => _resourceToGuess;
    private Resource.Suit _resourceToGuess;

    private void Awake()
    {
        _hidePanel.SetActive(true);
    }

    public void SetSuit(Resource.Suit suit)
    {
        _resourceToGuess = suit;
        _hiddenResourceDisplay.ShowResource(suit);
    }

    public bool CanReceiveDraggable(Idraggable draggable)
    {
        return draggable is Resource;
    }

    public void ReceiveDraggable(Idraggable draggable)
    {
        Resource resource = draggable as Resource;
        if (resource == null)
        {
            Debug.LogError("Something went wrong. Digit slot received an Idraggable it can't handle! ");
            return;
        }
        
        MakeAGuess(resource.ResourceSuit);
        resource.RemoveFromPlay();
    }

    private void MakeAGuess(Resource.Suit guess)
    {
        if (guess == _resourceToGuess)
        {
            _hidePanel.SetActive(false);
            _guessedResourceDisplay.gameObject.SetActive(false);
        }
        else
        {
            _guessedResourceDisplay.ShowResource(guess);
        }
    }
}
