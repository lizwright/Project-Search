using UnityEngine;

public class Resource : Draggable
{
    public enum Suit { Circle, Square, Triangle, Diamond }

    [HideInInspector]
    public ResourceHolder resourceHolder;

    [SerializeField] private Suit _resourceSuit;
    public Suit ResourceSuit => _resourceSuit;
    

    public void RemoveFromPlay()
    {
        resourceHolder.RemoveResource(this);
    }
}
