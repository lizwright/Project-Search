using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private DigitSequencer _digitSequencer;
   [SerializeField] private TraitsDisplay _traitsDisplay;
   [SerializeField] private EnemyIntentDisplay _intentDisplay;

   private int _actionsTakenIndex = 0;
   private EnemyData _data;

   public void Initialise(EnemyData enemyData)
   {
      _data = enemyData;
      
      _traitsDisplay.DisplayTraits(_data.Traits);
      _digitSequencer.CreateDigitSlots(_data.DigitSlotsCountCount);
      _digitSequencer.CreateSequence(_data.Traits);
      _intentDisplay.ShowIntent(_data.Actions[0]);
   }
   
   public void TakeTurn()
   {
      EnemyAction actionToTake = _data.Actions[_actionsTakenIndex % _data.Actions.Length];
      _actionsTakenIndex++;
      
      actionToTake.DoAction();
      _intentDisplay.ShowIntent(_data.Actions[_actionsTakenIndex % _data.Actions.Length]);

   }
}
