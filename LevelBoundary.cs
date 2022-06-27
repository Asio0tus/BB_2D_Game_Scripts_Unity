using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static LevelBoundary Instance;
    [SerializeField] private Vector2 screenResolution;

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if(Application.isEditor == false && Application.isPlaying == true)
        {
            screenResolution.y = Screen.height;
            screenResolution.x = Screen.width;
        }
    }

    public float LeftBorder
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        }
    }

    public float RightBorder
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(screenResolution.x, 0, 0)).x;
        }
    }
}
