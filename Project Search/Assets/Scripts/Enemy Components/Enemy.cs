using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDraggableReceiver
{
   public static event Action<Enemy> EnemyDied;
   [SerializeField] private DigitSequencer _digitSequencer;
   [SerializeField] private TraitsDisplay _traitsDisplay;
   [SerializeField] private EnemyIntentDisplay _intentDisplay;
   [SerializeField] private GuessedDigitTracker _guessedDigitTracker;

   private int _actionsTakenIndex = 0;
   private EnemyData _data;

   public void Initialise(EnemyData enemyData)
   {
      _data = enemyData;
      
      _traitsDisplay.DisplayTraits(_data.Traits);
      DigitSlot[] digitSlots = _digitSequencer.CreateDigitSlots(_data.DigitSlotsCountCount, _guessedDigitTracker);
      _digitSequencer.CreateSequence(_data.Traits);
      _guessedDigitTracker.Initialise(digitSlots, this);
      _intentDisplay.ShowIntent(_data.Actions[0]);
      
   }
   
   public void TakeTurn()
   {
      EnemyAction actionToTake = _data.Actions[_actionsTakenIndex % _data.Actions.Length];
      _actionsTakenIndex++;
      
      actionToTake.DoAction();
      _intentDisplay.ShowIntent(_data.Actions[_actionsTakenIndex % _data.Actions.Length]);

   }

   public void Die()
   {
      EnemyDied?.Invoke(this);
      
      Destroy( gameObject);
   }

   public bool CanReceiveDraggable(Idraggable draggable)
   {
      if (draggable is not ActionCard actionCard)
         return false;
      
      if (actionCard.Target != ActionCardData.ActionTarget.Enemy)
         return false;

      return true;
   }

   public void ReceiveDraggable(Idraggable draggable)
   {
      ActionCard actionCard = draggable as ActionCard;
      if (actionCard == null)
      {
         Debug.LogError("Something went wrong. Enemy received an Idraggable it can't handle! ");
         return;
      }
        
      actionCard.RemoveFromPlay();
      actionCard.DoAction(this);
   }
}
