using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ChangeArm : MonoBehaviour
{
    public PunchMode[] leftPunch;
    public PunchMode[] rightPunch;

    public void ChangeArme(ArmData armData, ArmSelect armSelect)
    {
        if (armSelect == ArmSelect.left)
        {
            foreach (PunchMode p in leftPunch)
            {
                if (p.punch.data.id == armData.id)
                {
                    p.parentPunch.SetActive(true);
                }
                else
                {
                    p.parentPunch.SetActive(false);
                }
            }
        }
        else if (armSelect == ArmSelect.right)
        {
            foreach (PunchMode p in rightPunch)
            {
                if (p.punch.data.id == armData.id)
                {
                    p.parentPunch.SetActive(true);
                }
                else
                {
                    p.parentPunch.SetActive(false);
                }
            }
        }
    }
}
