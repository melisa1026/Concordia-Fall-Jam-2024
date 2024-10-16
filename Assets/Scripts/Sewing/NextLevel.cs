using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    //attached to collider "Level Passed"

    public GameObject moveCamera;
    public GameObject needle;

    //position of camera for level 2
    public float xCamera;
    //position of needle for level 2
    public float xNeedle;
    public float yNeedle;

void OnTriggerEnter2D(Collider2D other)
    {
        moveCamera.transform.position = new Vector3(xCamera, 0, -10);
        needle.transform.position = new Vector3(xNeedle, yNeedle, 0);
    }
}
