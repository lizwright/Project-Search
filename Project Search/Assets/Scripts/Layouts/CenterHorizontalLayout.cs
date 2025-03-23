using Unity.VisualScripting;
using UnityEngine;

public class CenterHorizontalLayout : MonoBehaviour
{
   [SerializeField] private Transform centerTransform;
   [SerializeField] private float spacing;

   private Vector3 _centerPoint;

   private void Awake()
   {
      _centerPoint = centerTransform.position;
   }

   public void RemoveChildren(Transform parentTransform)
   {
      for (int i = parentTransform.childCount - 1; i >= 0; i--)
      {
         Destroy(parentTransform.GetChild(i).gameObject);
      }
   }

   public void Reposition(Object[] objArray)
   {
      Bounds[] bounds = new Bounds[objArray.Length];
      
      for (int i = 0; i < objArray.Length; i++)
      {
         Collider2D collider = objArray[i].GetComponent<Collider2D>();
         if (collider == null)
         {
            Debug.LogError("Can't reposition objects that don't have Collider2D's");
            return;
         }
         bounds[i] = collider.bounds;
      }

      float[] xPositions = CalculatePositions(bounds);
      
      for (int i = 0; i < objArray.Length; i++)
      {
         Transform objTransform = objArray[i].GetComponent<Transform>();
         Vector3 position = objTransform.position;
         position = new Vector3(xPositions[i], position.y, position.z);
         objTransform.position = position;
      }

   }

   private float[] CalculatePositions(Bounds[] bounds)
   {
      float[] positions = new float[bounds.Length];

      float totalWidth = 0;

      for (int i = 0; i < bounds.Length; i++)
      {
         totalWidth += bounds[i].size.x;
         
         if (i == bounds.Length - 1)
            continue;

         totalWidth += spacing;
      }

      float start = _centerPoint.x - totalWidth / 2;

      for (int i = 0; i < positions.Length; i++)
      {
         positions[i] = start + (spacing + bounds[i].size.x )* i + bounds[i].size.x /2;
      }
      return positions;
   }
   
}
