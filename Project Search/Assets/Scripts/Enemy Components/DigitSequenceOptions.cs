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
        Logger.Instance.LogDigitMessage($"Removing Suit {suit}");
        
        foreach (List<Resource.Suit> options in _digitOptions)
        {
            options.Remove(suit);
        }
    }

    public Resource.Suit GetRandomOptionForDigit(int digitIndex)
    {
        List<Resource.Suit> options = _digitOptions[digitIndex];
        
        if (options.Count == 0)
        {
            Debug.LogError("Tried to get an option for a digit but they have no valid options! This is a big error, don't ignore this!!! (Defaulting to Circle");
            return Resource.Suit.Circle;
        }
        
        int chosenIndex = Random.Range(0, options.Count);

        return options[chosenIndex];

    }

}
