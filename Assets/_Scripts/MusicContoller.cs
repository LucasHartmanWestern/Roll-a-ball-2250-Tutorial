using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContoller : MonoBehaviour
{
    private static MusicContoller _instance = null;
    public static MusicContoller Instance
    {
        get { return _instance; }
    }
    
    // Call when script is instantiated
    void Awake()
    {
        // Delete any duplicates of this instance (to avoid music playing twice)
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject); // Keep music between scenes
    }
}
