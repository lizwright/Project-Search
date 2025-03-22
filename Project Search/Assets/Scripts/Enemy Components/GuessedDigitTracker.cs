using System.Collections.Generic;
using UnityEngine;

public class GuessedDigitTracker : MonoBehaviour
{
    private Dictionary<DigitSlot, bool> _slotGuessedState;
    private Enemy _enemy;
    
    public void Initialise(DigitSlot[] digitSlots, Enemy enemy)
    {
        _enemy = enemy;
        
        _slotGuessedState = new Dictionary<DigitSlot, bool>(digitSlots.Length);
        for (int i = 0; i < digitSlots.Length; i++)
        {
            _slotGuessedState.Add(digitSlots[i], false);
        }
    }

    public void MarkSlotAsGuessed(DigitSlot slot)
    {
        _slotGuessedState[slot] = true;

        if (AreAllSlotsGuessed())
        {
            _enemy.Die();
        }
    }

    private bool AreAllSlotsGuessed()
    {
        foreach (KeyValuePair<DigitSlot,bool> slotPair in _slotGuessedState)
        {
            if (slotPair.Value == false)
                return false;
        }

        return true;
    }
    
}
