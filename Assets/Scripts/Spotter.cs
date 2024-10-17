using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// TODO: When moving from one grave the the other, disable the spotter

public class Spotter : MonoBehaviour
{
    public static bool isWatching = false;
    public float waitTime = 5, watchTime = 2, walkInTime = 2;

    public void Start()
    {
        // check where the bottom right corner of the screen is
        Vector3 bottomRightViewportPoint = new Vector3(1, 0, Camera.main.nearClipPlane);
        Vector3 bottomRightWorldPoint = Camera.main.ViewportToWorldPoint(bottomRightViewportPoint);

        transform.position = new Vector3(bottomRightWorldPoint.x+15, bottomRightWorldPoint.y, transform.position.z);

        StartCoroutine(spyTimer());
    }

    public IEnumerator spyTimer()
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(spyComes());
    }

    public IEnumerator spyComes()
    {
        // check where the bottom right corner of the screen is
        Vector3 bottomRightViewportPoint = new Vector3(1, 0, Camera.main.nearClipPlane);
        Vector3 bottomRightWorldPoint = Camera.main.ViewportToWorldPoint(bottomRightViewportPoint);

        GetComponent<Transform>().DOMove(bottomRightWorldPoint, walkInTime);
        yield return new WaitForSeconds(walkInTime);

        isWatching = true;
        yield return new WaitForSeconds(watchTime);
        isWatching = false;
        
        GetComponent<Transform>().DOMove(new Vector3(bottomRightWorldPoint.x+15, bottomRightWorldPoint.y, transform.position.z), walkInTime);
        yield return new WaitForSeconds(walkInTime);
        
        StartCoroutine(spyTimer());
    }
}
