using System.Collections.Generic;
using UnityEngine;

public class ResourcePool : MonoBehaviour
{
    private static Vector3 _poolPosition;
    private static  List<Resource> _resources;

    private void Awake()
    {
        _resources = new List<Resource>();
        _poolPosition = new Vector3(10000, 10000, 0);
    }

    public static void AddResource(Resource resource)
    {
        _resources.Add(resource);
        resource.transform.position = _poolPosition;
        resource.gameObject.SetActive(false);
    }
}
