using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private List<Trait> _traits;

   [SerializeField] private DigitSequencer _digitSequencer;
   [SerializeField] private TraitsDisplay _traitsDisplay;
   
   private void Start()
   {
      _traitsDisplay.DisplayTraits(_traits);
      _digitSequencer.CreateSequence(_traits);
   }
   
}
