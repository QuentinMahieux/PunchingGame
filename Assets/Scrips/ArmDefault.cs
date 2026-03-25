using UnityEngine;

public class ArmDefault : ArmBehaviour
{
    [Header("Player")]
    public PlayerController player;
    public ArmSelect armSelect;

    void OnEnable()
    {
        if (armSelect == ArmSelect.left)
        {
            player.armLeft = this;
        }
        else
        {
            player.armRight = this;
        }
    }
    
    public override void Strike()
    {
        base.Strike();
        StartCoroutine(StrikeCoroutine());
    }

    protected override void Update()
    {
        base.Update();
        if (isPunching)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,target.localPosition, Time.deltaTime * data.speed);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,defaultPosition.localPosition, Time.deltaTime * data.speed);
        }
    }
}
