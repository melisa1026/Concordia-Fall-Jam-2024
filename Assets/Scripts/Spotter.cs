using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// TODO: When moving from one grave the the other, disable the spotter

public class Spotter : MonoBehaviour
{
    public static bool isWatching = false;
    public float waitTime = 5, watchTime = 2, walkInTime = 2;
    public GameObject inSpot, outSpot;
    private bool spotterComing = false;
    private bool wasWalking = false;

    public void Start()
    {
        // check where the bottom right corner of the screen is

        transform.position = outSpot.transform.position;
        StartCoroutine(spyTimer());
    }

    public IEnumerator spyTimer()
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(spyComes());
    }

    public IEnumerator spyComes()
    {
        spotterComing = true;

        GetComponent<Transform>().DOMove(inSpot.transform.position, walkInTime);
        yield return new WaitForSeconds(walkInTime);

        isWatching = true;
        yield return new WaitForSeconds(watchTime);
        isWatching = false;
        
        GetComponent<Transform>().DOMove(outSpot.transform.position, walkInTime);
        yield return new WaitForSeconds(walkInTime);

        spotterComing = false;

        StartCoroutine(spyTimer());
    }

    void Update()
    {
        // if the player just started walking, make the spotter leave
        if(!wasWalking && PlayerControls.isWalking && spotterComing)
        {
            isWatching = false;
            GetComponent<Transform>().DOMove(outSpot.transform.position, walkInTime);
        }
        wasWalking = PlayerControls.isWalking;
    }
}
