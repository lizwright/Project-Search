using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHolder : MonoBehaviour
{
     private static  List<Resource> _resources;
     [SerializeField] private ResourcePool _resourcePool;

     [Header("placement settings")]
     [SerializeField] private Transform _startingTransform;
     [SerializeField] private float _offset;

     private Vector3 _startingPosition;

     private void Awake()
     {
          _startingPosition = _startingTransform.position;
          _resources = new List<Resource>(4);
          
          foreach (Transform child in transform)
          {
               Resource childResource = child.GetComponent<Resource>();
               if (childResource == null)
                    continue;
               childResource.resourceHolder = this;
               _resources.Add(childResource);
          }
     }
     
     public void RemoveResource (Resource resource)
     {
          _resources.Remove(resource);
          _resourcePool.AddResource(resource);
     }

     private void AddResource(Resource.Suit suit)
     {
          Resource resource = _resourcePool.TakeResource(suit);
          resource.resourceHolder = this;
          resource.gameObject.SetActive(true);


          resource.transform.position = new Vector3(
               _startingPosition.x + _offset * _resources.Count,
               _startingPosition.y,
               _startingPosition.z
          );
          
          _resources.Add(resource);
     }

     public void RefreshResources()
     {
          int resourceCount = _resources.Count;
          for (int i = 0; i < resourceCount; i++)
          {
               RemoveResource(_resources[0]);
          }
   
          Resource.Suit[] allSuits = (Resource.Suit[])Enum.GetValues(typeof(Resource.Suit));
          for (int i = 0; i < allSuits.Length; i++)
          {
               AddResource(allSuits[i]);
          }
          
     }
}
