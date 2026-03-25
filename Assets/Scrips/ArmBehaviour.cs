using System.Collections;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour
{
    public ArmData data;
    
    public Transform target;
    public Transform defaultPosition;

    public Rigidbody rb;
    
    [Header("State")]
    public bool isPunching;
    

    protected virtual void Update()
    {
        if (!isPunching && defaultPosition == target)
        {
            isPunching = false;
        }
    }

    public virtual void Strike()
    {
        if(isPunching) return;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(data.tag) && isPunching)
        {
            FightBehaviour cible =  other.GetComponent<FightBehaviour>();
            cible.Hit(data.damage);
        }
    }

    protected virtual IEnumerator StrikeCoroutine()
    {
        isPunching = true;
        yield return new WaitForSeconds(data.time);
        isPunching = false;
        transform.position = defaultPosition.position;
    }
}
