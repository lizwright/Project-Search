using UnityEngine;

public class Resource : MonoBehaviour, Idraggable
{
    private bool _beingHeld;
    
    public void OnPickUp()
    {
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
}
