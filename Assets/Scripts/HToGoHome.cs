using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HToGoHome : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H) || Input.GetButtonDown("HButton"))
        {
            SceneManager.LoadScene("Home");
        }
    }
}
