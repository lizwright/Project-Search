using UnityEngine;

public abstract class Draggable : MonoBehaviour, Idraggable
{
    private Vector3 _lastNonHeldPosition;
    private bool _beingHeld;

    public void OnPickUp()
    {
        _lastNonHeldPosition = transform.position;
        _beingHeld = true;
    }

    public void OnDrop()
    {
        _beingHeld = false;
    }

    private void Update()
    {
        if (_beingHeld == false)
            return;
        
        transform.position = InputManager.GetMouseWorldPosition(); 
    }
    
    public void OnNonReceivedDrop()
    {
        transform.position = _lastNonHeldPosition;
        _beingHeld = false;
    }
}
