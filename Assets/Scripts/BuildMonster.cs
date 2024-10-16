using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuildMonster : MonoBehaviour
{
    public GameObject torso;
    public GameObject[] parts;  // order: head, torso, right arm, left arm, right leg, left leg

    void Start()
    {
        // TODO: Change the bpdy part sprites to the ones the player chose
        if(ChosenItems.head != null)
            parts[0].GetComponent<SpriteRenderer>().sprite = ChosenItems.head;
        if(ChosenItems.torso != null)
            parts[1].GetComponent<SpriteRenderer>().sprite = ChosenItems.torso;
        if(ChosenItems.rightArm != null)
            parts[2].GetComponent<SpriteRenderer>().sprite = ChosenItems.rightArm;
        if(ChosenItems.leftArm != null)
            parts[3].GetComponent<SpriteRenderer>().sprite = ChosenItems.leftArm;
        if(ChosenItems.rightLeg != null)
            parts[4].GetComponent<SpriteRenderer>().sprite = ChosenItems.rightLeg;
        if(ChosenItems.leftLeg != null)
            parts[5].GetComponent<SpriteRenderer>().sprite = ChosenItems.leftLeg;

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
