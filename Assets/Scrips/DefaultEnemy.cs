using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DefaultEnemy : FightBehaviour
{
    [Header("Enemies")]
    public PlayerController actualTarget;
    
    public NavMeshAgent agent;

    public override void Start()
    {
        base.Start();
        agent.speed = entityData.speed;
    }

    void Update()
    {
        FindTarget();

        if (actualTarget && Vector3.Distance(transform.position, actualTarget.transform.position) <=
            entityData.distanceToPurchace && Vector3.Distance(transform.position, actualTarget.transform.position) > entityData.distanceToPush)
        {
            MoveToTarget();
        }
        else if (Vector3.Distance(transform.position, actualTarget.transform.position) <= entityData.distanceToPush)
        {
            agent.ResetPath();
        }
    }

    void FindTarget()
    {
        if(actualTarget == null) actualTarget = FlokManager.instance.players[0];
        foreach (PlayerController player in FlokManager.instance.players)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <=
                Vector3.Distance(transform.position, actualTarget.transform.position))
            {
                actualTarget = player;
            }
            
        }
    }
    
    void MoveToTarget()
    {
        agent.SetDestination(actualTarget.transform.position);
    }

    void WaitToTarget()
    {
        
    }
    
}
