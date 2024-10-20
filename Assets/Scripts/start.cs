using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start : MonoBehaviour
{

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("DButton"))
        {
            SceneManager.LoadScene("Phase I");
        }
    }

}
