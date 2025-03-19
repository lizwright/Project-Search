using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private List<Trait> _traits;
   [SerializeField] private EnemyAction[] _actions;

   [SerializeField] private DigitSequencer _digitSequencer;
   [SerializeField] private TraitsDisplay _traitsDisplay;
   [SerializeField] private EnemyIntentDisplay _intentDisplay;

   private int actionsTakenIndex = 0;
   
   private void Start()
   {
      _traitsDisplay.DisplayTraits(_traits);
      _digitSequencer.CreateSequence(_traits);
      _intentDisplay.ShowIntent(_actions[0]);
   }

   public void TakeTurn()
   {
      EnemyAction actionToTake = _actions[actionsTakenIndex % _actions.Length];
      actionsTakenIndex++;
      
      actionToTake.DoAction();
      _intentDisplay.ShowIntent(_actions[actionsTakenIndex % _actions.Length]);

   }
}
