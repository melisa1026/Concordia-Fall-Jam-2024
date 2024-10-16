using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{

    public GameObject lightBg;

    // Start is called before the first frame update
    void Start()
    {
        lightBg.SetActive(false);
        StartCoroutine(lightningClock());
    }

    IEnumerator lightningClock()
    {
        yield return new WaitForSeconds(6);
        lightBg.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        lightBg.SetActive(false);
        StartCoroutine(lightningClock());
    }
}
