using System.Collections.Generic;
using UnityEngine;

public class ResourceHolder : MonoBehaviour
{
     private static  List<Resource> _resources;

     private void Awake()
     {
          _resources = new List<Resource>(4);
          
          foreach (Transform child in transform)
          {
               Resource childResource = child.GetComponent<Resource>();
               _resources.Add(childResource);
          }
     }
     
     public static void RemoveResource (Resource resource)
     {
          _resources.Remove(resource);
     }
}
