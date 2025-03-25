using UnityEngine;

/// <summary>
/// for each digit slot on an enemy, make a random guess.
/// If the slot is already guessed, it's ignored.
/// </summary>
public class EliminateEnemySymbolsAction : ActionCardAction
{
    public override void DoAction(IDraggableReceiver receiver)
    {
        Enemy enemy = receiver as Enemy;
        if (enemy == null)
        {
            Debug.LogError("EliminateEnemySymbolsAction was used on something that wasn't an enemy. Can't do action!");
            return;
        }

        DigitSlot[] slots = enemy.GetComponentsInChildren<DigitSlot>();
        foreach (DigitSlot slot in slots)
        {
            if (slot.Guessed == true)
                continue;

            Resource.Suit suit = Resource.GetRandomSuit();
            
            slot.MakeAGuess(suit);

        }
    }
}
