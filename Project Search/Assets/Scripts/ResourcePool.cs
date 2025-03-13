using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePool : MonoBehaviour
{
    private Vector3 _poolPosition;
    private Dictionary<Resource.Suit, List<Resource>> _resources;
    
    [SerializeField] private GameObject _circleResource;
    [SerializeField] private GameObject _squareResource;
    [SerializeField] private GameObject _triangleResource;
    [SerializeField] private GameObject _diamondResource;

    private void Awake()
    {
        _resources = new Dictionary<Resource.Suit, List<Resource>>(4);
        
        Resource.Suit[] allSuits = (Resource.Suit[])Enum.GetValues(typeof(Resource.Suit));
        for (int i = 0; i < allSuits.Length; i++)
        {
            _resources.Add(allSuits[i], new List<Resource>(3));
        }
        
        _poolPosition = new Vector3(10000, 10000, 0);
    }

    public void AddResource(Resource resource)
    {
        if(_resources.TryGetValue(resource.ResourceSuit, out List<Resource> resourceList))
        {
            resourceList.Add(resource);
        }
        else
        {
            _resources.Add(resource.ResourceSuit, new List<Resource>{resource});
        }
        
        resource.transform.position = _poolPosition;
        resource.gameObject.SetActive(false);
    }

    public Resource TakeResource(Resource.Suit suit)
    {
        if (_resources.TryGetValue(suit, out List<Resource> resourceList))
        {
            if (resourceList.Count > 0)
            {
                Resource resource = resourceList[0];
                resourceList.RemoveAt(0);
                return resource;

            }
        }

        Resource newResource = CreateResource(suit);
        AddResource(newResource);

        if (newResource == null)
            return null;
        
        return TakeResource(suit);
    }

    private Resource CreateResource(Resource.Suit suit)
    {
        switch (suit)
        {
            case Resource.Suit.Circle:
                return Instantiate(_circleResource, _poolPosition, Quaternion.identity, transform).GetComponent<Resource>();
            case Resource.Suit.Square:
                return Instantiate(_squareResource, _poolPosition, Quaternion.identity, transform).GetComponent<Resource>();
            case Resource.Suit.Triangle:
                return Instantiate(_triangleResource, _poolPosition, Quaternion.identity, transform).GetComponent<Resource>();
            case Resource.Suit.Diamond:
                return Instantiate(_diamondResource, _poolPosition, Quaternion.identity, transform).GetComponent<Resource>();
        }
        Debug.LogError($"Tried to Create resource with a suit I don't recongise suit: {suit.ToString()}");
        return null;
    }
}
