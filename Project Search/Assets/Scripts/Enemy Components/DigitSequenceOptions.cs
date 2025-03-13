using System.Collections.Generic;
using UnityEngine;

public class DigitSequenceOptions
{
    public List<Resource.Suit>[] Options => _digitOptions;
    private List<Resource.Suit>[] _digitOptions;
    
    public DigitSequenceOptions(int digitSlotsCount)
    {
        _digitOptions = new List<Resource.Suit>[digitSlotsCount];
        for (int i = 0; i < _digitOptions.Length; i++)
        {
            _digitOptions[i] = new List<Resource.Suit>
            {
                Resource.Suit.Circle,
                Resource.Suit.Square,
                Resource.Suit.Triangle,
                Resource.Suit.Diamond,
            };
        }
    }

    public void RemoveSuitFromAll(Resource.Suit suit)
    {
        Debug.Log($"Removing Suit {suit}");
        
        foreach (List<Resource.Suit> options in _digitOptions)
        {
            options.Remove(suit);
        }
    }

}
