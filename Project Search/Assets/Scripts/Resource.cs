using UnityEngine;

public class Resource : MonoBehaviour, Idraggable
{
    public enum Suit { Circle, Square, Triangle, Diamond }

    [HideInInspector]
    public ResourceHolder resourceHolder;

    [SerializeField] private Suit _resourceSuit;
    public Suit ResourceSuit => _resourceSuit;

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
        resourceHolder.RemoveResource(this);
    }
}
