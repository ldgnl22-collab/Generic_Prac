using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private static PlayerInputManager instance;
    
    public static PlayerInputManager Instance
    {
        get{ return instance; }
    }
    
    private void Awake() => SetSingleton();
    
    
    
    private void SetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
