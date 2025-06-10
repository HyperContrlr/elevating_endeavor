using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Scriptable Objects/Attack")]
public abstract class Attack : ScriptableObject
{
    public float damage;

    public float attackRadius;

    public float attackStartup;

    public float attackDuration;

    public float attackDissipation;

    public float cooldown;

    public abstract void OnUse();
}
