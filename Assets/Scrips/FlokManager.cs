using System.Collections.Generic;
using UnityEngine;

public class FlokManager : MonoBehaviour
{
    public static FlokManager instance;

    public List<PlayerController> players;
    
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one instance of FlokManager!");
            Destroy(this);
        }
    }

    void Update()
    {
        
    }
}
