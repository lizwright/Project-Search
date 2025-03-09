using UnityEngine;

public class Resource : MonoBehaviour, Idraggable
{
    private bool _beingHeld;
    private Vector3 _lastNonHeldPosition;
    
    public void OnPickUp()
    {
        _lastNonHeldPosition = transform.position;
        _beingHeld = true;
    }

    public void OnDrop()
    {
        _beingHeld = false;
    }

    public void OnNonReceivedDrop()
    {
        transform.position = _lastNonHeldPosition;
        _beingHeld = false;
    }

    private void Update()
    {
        if (_beingHeld == false)
            return;
        
        transform.position = InputManager.GetMouseWorldPosition();
    }

    public void RemoveFromPlay()
    {
        ResourceHolder.RemoveResource(this);
        ResourcePool.AddResource(this);
    }
}
