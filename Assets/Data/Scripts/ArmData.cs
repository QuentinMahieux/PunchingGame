using UnityEngine;

[CreateAssetMenu(fileName = "ArmData", menuName = "Scriptable Objects/ArmData")]
public class ArmData : ScriptableObject
{
    public int id;
    [Header("Punch")]
    public float speed = 5f;
    public float time = 0.5f;
    public float force = 3f;
    public float timeForce = 0.2f;

    [Header("Enemy")] 
    public string tag;
    public float damage = 4f;
}
