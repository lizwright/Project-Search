using System;
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
    
    public static Suit GetRandomSuit()
    {
        Array values = Enum.GetValues(typeof(Suit));
        return (Suit)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }
}
