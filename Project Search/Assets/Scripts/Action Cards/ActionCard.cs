using System;
using TMPro;
using UnityEngine;

public class ActionCard : Draggable
{
    public bool IsReady => _isReady;
    public ActionCardData.ActionTarget Target => _target; 
    
    [SerializeField] private ActionCardResourceSlot _resourceSlot;
    [SerializeField] private CostGauge _gauge;
    [SerializeField] private TMP_Text _nameLabel;

    private bool _isReady;
    private ActionCardData.ActionTarget _target;
    private ActionCardData _data;
    private Resource.Suit _lastReceivedSuit;

    public override bool AllowPickUp()
    {
        return _isReady;
    }

    public void Initialise(ActionCardData data)
    {
        _data = data;
        
        _gauge.Initialise(data.Cost);
        
        _isReady = data.Cost == 0;

        _target = data.Target;

        _nameLabel.text = data.CardName;
    }

    public void RemoveFromPlay()
    {
        transform.position = new Vector3(1000, 1000, transform.position.z);
    }

    public void DoAction(IDraggableReceiver receiver)
    {
        Type type = _data.Script.GetClass();
        if (type != null && type.IsClass && !type.IsAbstract)
        {
            object actionObj = Activator.CreateInstance(type);
            if (actionObj is ActionCardAction action)
            {
                action.DoAction(receiver, _lastReceivedSuit);
                return;
            }
        }
        Debug.LogError("Tried to do action. Something went wrong!");
    }

    public void GainResource(Resource resource)
    {
        _lastReceivedSuit = resource.ResourceSuit;
        
        _gauge.PayCost();
        _isReady = _gauge.IsFull;

        if (_data.SuitDependent )
        {
            if(_gauge.OnFinalMarker)
                _resourceSlot.ShowSuitDependentView();
            if(_gauge.IsFull)
                _resourceSlot.ShowSuit(_lastReceivedSuit);
        }
    }
}
