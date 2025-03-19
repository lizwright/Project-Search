using UnityEngine;

[CreateAssetMenu(fileName = "Attack_EnemyAction", menuName = "ScriptableObjects/Enemy Actions/Attack")]
public class AttackAction : EnemyAction
{
    public int damage => _damage;
    [SerializeField] private int _damage;

    public override void DoAction()
    {
        PlayerHealth.Instance.ReduceHealth(_damage);
    }
}
