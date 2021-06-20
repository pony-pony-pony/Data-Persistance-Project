using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMainManager : MonoBehaviour
{
    public static MainMainManager Instance;
    public string Name;
   
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
        
    }

}
