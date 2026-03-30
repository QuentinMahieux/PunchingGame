using System.Collections;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour
{
    public ArmData data;
    
    public Transform target;
    public Transform defaultPosition;

    
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
        Debug.Log("Touche truc");
        if (other.CompareTag(data.tag) && isPunching)
        {
            Debug.Log("Touche un enemie");
            DefaultEnemy cible = other.GetComponent<DefaultEnemy>();
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
