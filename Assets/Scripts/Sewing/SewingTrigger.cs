using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewingTrigger : MonoBehaviour
{
    //attach to colliders

    public GameObject needlePoint;
    public GameObject needle;
    public GameObject red;
    //starting coordinates for needle in level 1
    public float X;
    public float Y;

    void OnTriggerEnter2D(Collider2D other)
    {
        needle.transform.position = new Vector3(X, Y, 0);
        //clear line renderer
        needlePoint.GetComponent<LineRenderer>().positionCount = 0;
        //red flash to indicate loss
        StartCoroutine(lost());
    }

    //red flash to indicate loss
    public IEnumerator lost()
    {
        red.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        red.SetActive(false);
    }
}
