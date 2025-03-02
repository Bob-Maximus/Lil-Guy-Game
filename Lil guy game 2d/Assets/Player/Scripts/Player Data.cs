using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "PlayerData", menuName = "Scriptable Objects / Player Data")]
public class PlayerData : ScriptableObject
{
    public float speed;
    public float acceleration;
    public float jumpHeight;
    public bool canFly;
}
