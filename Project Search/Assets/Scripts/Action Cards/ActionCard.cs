using UnityEngine;

public class ActionCard : Draggable
{
    public bool IsReady => _isReady;
    
    [SerializeField] private ActionCardResourceSlot _resourceSlot;
    [SerializeField] private CostGauge _gauge;

    private bool _isReady;

    public void Initialise(ActionCardData data)
    {
        _gauge.Initialise(data.Cost);
        
        _isReady = data.Cost == 0;
    }

    public void GainResource(Resource _)
    {
        //right now we don't care about the resource, only that one was received;
        _gauge.PayCost(1);
        _isReady = _gauge.IsFull;
    }
}
