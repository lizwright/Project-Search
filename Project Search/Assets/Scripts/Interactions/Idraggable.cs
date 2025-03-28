public interface Idraggable
{
   public bool AllowPickUp();
   public void OnPickUp();

   public void OnDrop();

   public void OnNonReceivedDrop();
}
