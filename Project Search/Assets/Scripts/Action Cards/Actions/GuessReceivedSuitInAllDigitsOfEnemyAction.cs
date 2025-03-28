using UnityEngine;

/// <summary>
/// for each digit slot on an enemy, make a guess of the last received suit.
/// /// If the slot is already guessed, it's ignored.
/// </summary>
public class GuessReceivedSuitInAllDigitsOfEnemyAction : ActionCardAction
{
    public override void DoAction(IDraggableReceiver receiver, Resource.Suit lastSuitReceived)
    {
        Enemy enemy = receiver as Enemy;
        if (enemy == null)
        {
            Debug.LogError("GuessReceivedSuitInAllDigitsOfEnemyAction was used on something that wasn't an enemy. Can't do action!");
            return;
        } 
        
        DigitSlot[] slots = enemy.GetComponentsInChildren<DigitSlot>();
        foreach (DigitSlot slot in slots)
        {
            if (slot.Guessed)
                continue;
            
            slot.MakeAGuess(lastSuitReceived);

        }
    }
}
