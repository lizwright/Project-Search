using UnityEngine;
using UnityEngine.InputSystem;

public class GameHand : MonoBehaviour
{
    private LayerMask _interactableLayer;
    private Idraggable _heldDraggable;
    private RaycastHit2D[] _raycastHits;

    private void Awake()
    {
        _interactableLayer = LayerMask.GetMask("Interactable");
        _raycastHits = new RaycastHit2D[4];
    }

    private void OnEnable()
    {
        InputManager.Actions.Game.PickUp.performed += PickUp;
        InputManager.Actions.Game.PickUp.canceled += Drop;
    }

    private void OnDisable()
    {
        InputManager.Actions.Game.PickUp.performed -= PickUp;
        InputManager.Actions.Game.PickUp.canceled -= Drop;
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

       if (RaycastFoDraggableReceiver(out IDraggableReceiver receiver))
       {
           if (receiver.CanReceiveDraggable(_heldDraggable))
           {
               _heldDraggable.OnDrop();
               receiver.ReceiveDraggable(_heldDraggable);
               _heldDraggable = null;
               return;
           }
       }
       
       _heldDraggable.OnNonReceivedDrop();
       _heldDraggable = null;
    }

    private bool RaycastForDraggable(out Idraggable draggable)
    {
        return RaycastForInteractable(out draggable);
    }
    
    private bool RaycastFoDraggableReceiver(out IDraggableReceiver receiver)
    {
        return RaycastForInteractable(out receiver);
    }

    private bool RaycastForInteractable<T>(out T target)
    {
        target = default(T);
        int hitCount = Physics2D.RaycastNonAlloc(transform.position, Vector3.forward, _raycastHits,1000, _interactableLayer);
        
        for (int i = 0; i < hitCount; i++)
        {
            RaycastHit2D currentHit = _raycastHits[i];
            if (currentHit.collider != null)
            {
                GameObject hitObject = currentHit.collider.gameObject;
                Component component = hitObject.GetComponent(typeof(T));
                if (component is T typedComponent)
                {
                    target = typedComponent;
                    return true;
                }
            } 
        }

        return false;
    }
}
