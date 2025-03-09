public interface IDraggableReceiver
{
   public bool CanReceiveDraggable(Idraggable draggable);

   public void ReceiveDraggable(Idraggable draggable);
}
