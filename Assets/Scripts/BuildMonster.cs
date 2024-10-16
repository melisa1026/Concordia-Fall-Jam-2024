using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuildMonster : MonoBehaviour
{
    public GameObject torso;
    public GameObject[] parts;

    void Start()
    {
        // TODO: Change the bpdy part sprites to the ones the player chose
        
        StartCoroutine(openLab());
    }

    IEnumerator openLab()
    {
        yield return new WaitForSeconds(1.5f);
        build();
    }

    public void build()
    {
        for(int i = 0; i < parts.Length; i++)
        {
            parts[i].GetComponent<Transform>().DOMove(torso.GetComponent<Transform>().position, 0.3f);
        }
    }
}
