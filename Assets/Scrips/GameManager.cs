using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Cursor")] 
    public bool isVisible = true;
    public CursorLockMode cursorLockMode = CursorLockMode.Confined;
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one GameManager in scene.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Cursor.visible = isVisible;
        Cursor.lockState = cursorLockMode;
    }

    void Update()
    {
        
    }
}
