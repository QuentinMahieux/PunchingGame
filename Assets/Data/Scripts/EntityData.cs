using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Scriptable Objects/EntityData")]
public class EntityData : ScriptableObject
{
    public string entityName;
    public float maxHealth;
    public float speed;

    [Header("Enemies")] 
    public float distanceToPurchace = 14f;
    public float distanceToWait = 6f;
    public float distanceToPush = 2f;
}
