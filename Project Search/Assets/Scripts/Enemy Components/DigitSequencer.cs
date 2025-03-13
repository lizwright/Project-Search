using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DigitSequencer : MonoBehaviour
{
    [SerializeField] private List<Trait> _traits;
    [SerializeField] private DigitSlot[] _digitSlots;

    private DigitSequenceOptions _digitOptions;

    private void Awake()
    {
        CreateSequence();
    }

    public void CreateSequence()
    {
        // init digit options
        
        _digitOptions = new DigitSequenceOptions(_digitSlots.Length);

        DebugPrintDigitOptions("initial options:");
        
        //sort traits into priority order
        _traits.Sort((a,b) => a.Priority.CompareTo(b.Priority));

        //apply pre choosing effects
        for (int i = 0; i < _traits.Count; i++)
        {
            _traits[i].ApplyPreChoosingEffects(_digitOptions);
        }

        DebugPrintDigitOptions("after pre-choosing effect options options:");
        
        //chose digits
        for (int i = 0; i < _digitSlots.Length; i++)
        {
            DigitSlot slot = _digitSlots[i];
            slot.SetSuit(_digitOptions.GetRandomOptionForDigit(i));
        }

        DebugPrintDigitSequence("Chosen Sequence: ");

    }

    private void DebugPrintDigitOptions(string openingMessage = "")
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(openingMessage);
        
        for (int i = 0; i < _digitOptions.Options.Length; i++)
        {
            sb.Append($"slot {i}:");
            List<Resource.Suit> currentList = _digitOptions.Options[i];
            if (currentList.Contains(Resource.Suit.Circle))
            {
                sb.Append(" Circle ");
            }
            if (currentList.Contains(Resource.Suit.Square))
            {
                sb.Append(" Square ");
            }
            if (currentList.Contains(Resource.Suit.Triangle))
            {
                sb.Append(" Triangle ");
            }
            if (currentList.Contains(Resource.Suit.Diamond))
            {
                sb.Append(" Diamond ");
            }

            sb.AppendLine();
        }
        
        Debug.Log(sb);
    }

    private void DebugPrintDigitSequence(string openingMessage = "")
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(openingMessage);

        for (int i = 0; i < _digitSlots.Length; i++)
        {
            DigitSlot slot = _digitSlots[i];
            sb.Append($" {slot.ResourceToGuess.ToString()} ");
        }
        
        Debug.Log(sb);

    }
}
