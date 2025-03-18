using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private List<Trait> _traits;
   [SerializeField] private EnemyAction[] _actions;

   [SerializeField] private DigitSequencer _digitSequencer;
   [SerializeField] private TraitsDisplay _traitsDisplay;

   private int actionsTakenIndex = 0;
   
   private void Start()
   {
      _traitsDisplay.DisplayTraits(_traits);
      _digitSequencer.CreateSequence(_traits);
   }

   public void TakeTurn()
   {
      EnemyAction actionToTake = _actions[actionsTakenIndex % _actions.Length];
      actionsTakenIndex++;
      
      actionToTake.DoAction();
   }
}
