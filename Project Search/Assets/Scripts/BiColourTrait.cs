using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "BiColour_Trait", menuName = "ScriptableObjects/Traits/Bi Colour")]
public class BiColourTrait : Trait
{
    public override void ApplyPreChoosingEffects(DigitSequenceOptions digitOptions)
    {
        int[] valuesArray = (int[])Enum.GetValues(typeof(Resource.Suit));
        List<int> values = new List<int>(valuesArray);
        
        List<int> suitsToKeep = new List<int>(2);
        
        for (int i = 0; i < 2; i++)
        {
            int suitIndex = Random.Range(0, values.Count);
            suitsToKeep.Add(suitIndex);
            values.RemoveAt(suitIndex);
        }

        for (int i = 0; i < valuesArray.Length; i++)
        {
            if(suitsToKeep.Contains(i))
                continue;
            
            digitOptions.RemoveSuitFromAll((Resource.Suit)i);
        }

    }
}
