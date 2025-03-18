using UnityEngine;

[CreateAssetMenu(fileName = "Attack_EnemyAction", menuName = "ScriptableObjects/Enemy Actions/Attack")]
public class AttackAction : EnemyAction
{
    [SerializeField] private int _damage;

    public override void DoAction()
    {
        Debug.Log($" Doing {_damage} damage to player");
    }
}
