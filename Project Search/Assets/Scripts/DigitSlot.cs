using UnityEngine;

public class DigitSlot : MonoBehaviour, IDraggableReceiver
{
    public bool CanReceiveDraggable(Idraggable draggable)
    {
        return draggable is Resource;
    }

    public void ReceiveDraggable(Idraggable draggable)
    {
        Resource resource = draggable as Resource;
        Debug.Log($"Dropped {resource.name} onto a slot!");
        Destroy(resource.gameObject);
        //resource.RemoveFromPlay();
    }
}
