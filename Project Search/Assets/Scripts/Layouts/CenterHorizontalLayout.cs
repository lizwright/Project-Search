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


   public float[] CalculatePositions(Bounds[] bounds)
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
