using UnityEngine;

public class FightBehaviour : MonoBehaviour
{
    public EntityData entityData;
    [Header("Life")]
    public float currentLife;
    
    public ArmBehaviour armLeft;
    public ArmBehaviour armRight;
    
    public virtual void Start()
    {
        currentLife = entityData.maxHealth;
    }
    
    public virtual void StartStrike(ArmSelect armSelect)
    {
        if (armSelect == ArmSelect.left)
        {
            armLeft.Strike();
        }
        else if (armSelect == ArmSelect.right)
        {
            armRight.Strike();
        }
    }

    public virtual void Hit(float damage)
    {
        currentLife -= damage;
        Death();
    }

    public virtual void Death()
    {
        if (currentLife <= 0)
        {
            Debug.Log(entityData.entityName + " is Dead");
            Destroy(gameObject);
        }
    }
}
public enum ArmSelect
{
    left,
    right
}
