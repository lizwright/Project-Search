using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "NoSuit_Trait", menuName = "ScriptableObjects/Traits/No Suit")]
public class NoSuitTrait : Trait
{
    public override void ApplyPreChoosingEffects(ref List<Resource.Suit>[] digitOptions)
    {
        Array values = Enum.GetValues(typeof(Resource.Suit));
        Resource.Suit suitToRemove = (Resource.Suit)values.GetValue(Random.Range(0,values.Length));
        foreach (List<Resource.Suit> options in digitOptions)
        {
            options.Remove(suitToRemove);
        }
    }
}
