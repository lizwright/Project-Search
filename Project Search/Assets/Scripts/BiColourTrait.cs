
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BiColour_Trait", menuName = "ScriptableObjects/Traits/Bi Colour")]
public class BiColourTrait : Trait
{
    public override void ApplyPreChoosingEffects(ref List<Resource.Suit>[] digitOptions)
    {
        Debug.Log("Bi colour not ready for use yet!");
    }
}
