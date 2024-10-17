using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{

    public GameObject lightBg;
    public SpriteRenderer[] trees;
    public Sprite defaultTrees, lightningTrees;

    // Start is called before the first frame update
    void Start()
    {
        lightBg.SetActive(false);
        StartCoroutine(lightningClock());
    }

    IEnumerator lightningClock()
    {
        yield return new WaitForSeconds(6);
        for(int i=0; i< trees.Length; i++)
        {   
            trees[i].sprite = lightningTrees;
        }
        lightBg.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        for(int i=0; i< trees.Length; i++)
        {   
            trees[i].sprite = defaultTrees;
        }
        lightBg.SetActive(false);
        StartCoroutine(lightningClock());
    }
}
