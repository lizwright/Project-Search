using UnityEngine;

public class ActionCardResourceSlot : MonoBehaviour, IDraggableReceiver
{
    [SerializeField] private ActionCard _actionCard;
    [SerializeField] private GameObject _suitDependentView;
    [SerializeField] private ResourceDisplay _resourceDisplay;
    
    public bool CanReceiveDraggable(Idraggable draggable)
    {
        if (draggable is not Resource)
            return false;
        
        if (_actionCard.IsReady)
            return false;

        return true;
    }

    public void ReceiveDraggable(Idraggable draggable)
    {
        Resource resource = draggable as Resource;
        if (resource == null)
        {
            Debug.LogError("Something went wrong. Action Card Slot received an Idraggable it can't handle! ");
            return;
        }

        _actionCard.GainResource(resource);
        resource.RemoveFromPlay();

    }

    public void ShowSuitDependentView()
    {
        _resourceDisplay.HideAllResources();
        _suitDependentView.SetActive(true);
    }

    public void ShowSuit(Resource.Suit suit)
    {
        _suitDependentView.SetActive(false);
        _resourceDisplay.ShowResource(suit);
    }

    public void HideSuitDependentDisplay()
    {
        _suitDependentView.SetActive(false);
        _resourceDisplay.HideAllResources();
    }
}
