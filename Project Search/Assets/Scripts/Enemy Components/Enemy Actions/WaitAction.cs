using UnityEngine;

[CreateAssetMenu(fileName = "Wait_EnemyAction", menuName = "ScriptableObjects/Enemy/Actions/Wait")]
public class WaitAction : EnemyAction
{
    
    public override void DoAction()
    {
       // Debug.Log("Enemy Waiting");
    }
}
