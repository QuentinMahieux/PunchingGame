using UnityEngine;

public class LootArm : MonoBehaviour
{
    public ArmData newArmData;

    public bool isEnter;
    public ChangeArm changeArm;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isEnter = true;
            changeArm = other.gameObject.GetComponent<ChangeArm>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEnter = false;
        }
    }

    void Update()
    {
        if(!isEnter) return;
        if (Input.GetKeyDown(KeyCode.P))
        {
            IsSelected(ArmSelect.left);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            IsSelected(ArmSelect.right);
        }
    }

    void IsSelected(ArmSelect armSelect)
    {
        if (!changeArm) return;
        changeArm.ChangeArme(newArmData, armSelect);
    }
}
