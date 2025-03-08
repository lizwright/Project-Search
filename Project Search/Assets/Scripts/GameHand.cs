using UnityEngine;
using UnityEngine.InputSystem;

public class GameHand : MonoBehaviour
{
    private LayerMask _interactableLayer;
    private Idraggable _heldDraggable;

    private void Awake()
    {
        _interactableLayer = LayerMask.GetMask("Interactable");
    }

    private void OnEnable()
    {
        InputManager.Actions.Game.PickUp.performed += PickUp;
        InputManager.Actions.Game.PickUp.canceled += Drop;
    }

    private void Update()
    {
        transform.position = InputManager.GetMouseWorldPosition();
    }

    private void PickUp(InputAction.CallbackContext _)
    {
        if (RaycastForDraggable(out Idraggable hitDraggable))
        {
            _heldDraggable = hitDraggable;
            hitDraggable.OnPickUp();
        }
    }

    private void Drop(InputAction.CallbackContext _)
    {
       if(_heldDraggable == null) 
           return;
       
       _heldDraggable.OnDrop();
       _heldDraggable = null;
    }

    private bool RaycastForDraggable(out Idraggable draggable)
    {
        draggable = null;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.forward, 1000, _interactableLayer);
        if(hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            Component component = hitObject.GetComponent(typeof(Idraggable));
            if (component is Idraggable hitDraggable)
            {
                draggable = hitDraggable;
                return true;
            }
        }

        return false;
    }
}
