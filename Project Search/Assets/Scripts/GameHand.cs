using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameHand : MonoBehaviour
{
    private LayerMask _interactableLayer;
    private Idraggable _heldDraggable;
    private RaycastHit2D[] _raycastHits;
    private List<IHoverable> _currentHoverables;

    private void Awake()
    {
        _currentHoverables = new List<IHoverable>();
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
        Hover();
    }

    private void Hover()
    {
        RaycastForHoverable(out IHoverable[] hitHoverables);
        //check if current hovers are in hit list. If not call their exit and remove
        for (int i = _currentHoverables.Count - 1; i >= 0; i--)
        {
            IHoverable currentHoverable = _currentHoverables[i];
            bool found = false;
            foreach (var hitHoverable in hitHoverables)
            {
                if (currentHoverable == hitHoverable)
                {
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                currentHoverable.OnHoverExit();
                _currentHoverables.Remove(currentHoverable);
            }
        }
        
        //for all hits, if you're not in the current list, call their enter and add them
        for (int i = hitHoverables.Length - 1; i >= 0; i--)
        {
            var currentHit = hitHoverables[i];
            if (_currentHoverables.Contains(currentHit) == false)
            {
                currentHit.OnHoverEnter();
                _currentHoverables.Add(currentHit);
            }
        }
    }
    
    private void PickUp(InputAction.CallbackContext _)
    {
        if (RaycastForDraggable(out Idraggable[] hitDraggables))
        {
            foreach (var hitDraggable in hitDraggables)
            {
                if (hitDraggable.AllowPickUp() == false)
                    return;
                _heldDraggable = hitDraggable;
                hitDraggable.OnPickUp();
                return;
            }
            
        }
    }

    private void Drop(InputAction.CallbackContext _)
    {
       if(_heldDraggable == null) 
           return;

       if (RaycastFoDraggableReceiver(out IDraggableReceiver[] receivers))
       {
           foreach (IDraggableReceiver receiver in receivers)
           {
               if (receiver.CanReceiveDraggable(_heldDraggable))
               {
                   _heldDraggable.OnDrop();
                   receiver.ReceiveDraggable(_heldDraggable);
                   _heldDraggable = null;
                   return;
               }
           }

       }
       
       _heldDraggable.OnNonReceivedDrop();
       _heldDraggable = null;
    }

    private bool RaycastForHoverable(out IHoverable[] hoverable)
    {
        return RaycastForInteractable(out hoverable);
    }
    
    private bool RaycastForDraggable(out Idraggable[] draggable)
    {
        return RaycastForInteractable(out draggable);
    }
    
    private bool RaycastFoDraggableReceiver(out IDraggableReceiver[] receiver)
    {
        return RaycastForInteractable(out receiver);
    }

    private bool RaycastForInteractable<T>(out T[] target)
    {
        target = default(T[]);
        List<T> hitTargets = new List<T>();
        
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
                    hitTargets.Add(typedComponent);
                }
            } 
        }

        target = hitTargets.ToArray();

        return hitTargets.Count > 0;
    }
}
