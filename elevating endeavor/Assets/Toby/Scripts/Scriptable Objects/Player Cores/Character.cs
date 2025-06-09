using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character")]
public class Character : ScriptableObject
{
    public float hp;

    public float moveSpeed;

    public float jumpForce;

    public float cooldownDecrease;

    public string characterName;
}
