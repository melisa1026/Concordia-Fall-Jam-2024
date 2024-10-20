using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    static bool instance = false;
     void Awake()
    {
        if(instance == false)
        {
            instance = true;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);
    }
}
