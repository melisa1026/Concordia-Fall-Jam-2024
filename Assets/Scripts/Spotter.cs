using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// TODO: When moving from one grave the the other, disable the spotter

public class Spotter : MonoBehaviour
{
    public static bool isWatching = false;
    public float waitTime = 5, watchTime = 2, walkInTime = 2, initialWaitTime = 3;
    public GameObject inSpot, outSpot;
    public static bool spotterComing = false;
    private bool wasWalking = false;

    public void Start()
    {
        wasWalking = false;
        spotterComing = false;
        isWatching = false;

        // check where the bottom right corner of the screen is

        transform.position = outSpot.transform.position;
        StartCoroutine(startTimer());
    }

    public IEnumerator startTimer()
    {
        yield return new WaitForSeconds(initialWaitTime);
        StartCoroutine(spyTimer());
    }

    public IEnumerator spyTimer()
    {

        yield return new WaitForSeconds(waitTime);
        
        if(!PlayerControls.isWalking && !spotterComing)
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
        }
        else
        {
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(spyTimer());

    }


    void Update()
    {
        // if the player just started walking, make the spotter leave
        if(!wasWalking && PlayerControls.isWalking)
        {
            isWatching = false;

            GetComponent<Transform>().DOMove(outSpot.transform.position, walkInTime);
        }

        if(PlayerControls.isWalking && isWatching)
        {
            isWatching = false;
        }
        wasWalking = PlayerControls.isWalking;
    }
}
