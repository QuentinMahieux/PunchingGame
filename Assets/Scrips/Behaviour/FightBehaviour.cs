using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightBehaviour : MonoBehaviour
{
    public EntityData entityData;
    [Header("Life")]
    public float currentLife;
    
    public ArmBehaviour armLeft;
    public ArmBehaviour armRight;
    
    public bool isPunching = false;

    
    public virtual void Start()
    {
        armLeft.Strike();
        armRight.Strike();
        currentLife = entityData.maxHealth;
    }
    
    protected virtual void StartStrike(ArmSelect armSelect)
    {
        if (armSelect == ArmSelect.left)
        {
            armLeft.Strike();
            StartCoroutine(PushForce(armLeft));
        }
        else if (armSelect == ArmSelect.right)
        {
            armRight.Strike();
            StartCoroutine(PushForce(armRight));
        }
    }

    protected virtual IEnumerator PushForce(ArmBehaviour arm)
    {
        yield return new WaitForSeconds(0);
    }

    

    public virtual void Hit(float damage)
    {
        Debug.Log(entityData.entityName + " hit " + damage);
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
