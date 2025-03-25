using UnityEngine;

public class ActionCard : Draggable
{
    public bool IsReady => _isReady;
    public ActionCardData.ActionTarget Target => _target; 
    
    [SerializeField] private ActionCardResourceSlot _resourceSlot;
    [SerializeField] private CostGauge _gauge;

    private bool _isReady;
    private ActionCardData.ActionTarget _target;

    public override void OnPickUp()
    {
        if(_isReady)
            base.OnPickUp();
    }

    public override void OnNonReceivedDrop()
    {
        if(_isReady)
            base.OnNonReceivedDrop();
    }

    public void Initialise(ActionCardData data)
    {
        _gauge.Initialise(data.Cost);
        
        _isReady = data.Cost == 0;

        _target = data.Target;
    }

    public void RemoveFromPlay()
    {
        transform.position = new Vector3(1000, 1000, transform.position.z);
    }

    public void DoAction()
    {
        Debug.Log("Action card would do something here!");
    }

    public void GainResource(Resource _)
    {
        //right now we don't care about the resource, only that one was received;
        _gauge.PayCost(1);
        _isReady = _gauge.IsFull;
    }
}
