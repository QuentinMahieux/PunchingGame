using UnityEngine;

[CreateAssetMenu(fileName = "ArmData", menuName = "Scriptable Objects/ArmData")]
public class ArmData : ScriptableObject
{
    public int id;
    [Header("Punch")]
    public float speed = 5f;
    public float time = 0.5f;

    [Header("Enemy")] 
    public string tag;
    public float damage = 4f;
}
