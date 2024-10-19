using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuildMonster : MonoBehaviour
{
    public GameObject torso = null;
    public GameObject[] parts;  // order: torso, head, right arm, left arm, right leg, left leg
    public bool assemble = true;

    void Start()
    {
        // Change the bpdy part sprites to the ones the player chose
        parts[0].GetComponent<SpriteRenderer>().sprite = Pickups.getNonCenteredPart(0, ChosenItems.chosenItems[0]);
        parts[1].GetComponent<SpriteRenderer>().sprite = Pickups.getNonCenteredPart(1, ChosenItems.chosenItems[1]);
        parts[2].GetComponent<SpriteRenderer>().sprite = Pickups.getNonCenteredPart(2, ChosenItems.chosenItems[2]);
        parts[3].GetComponent<SpriteRenderer>().sprite = Pickups.getNonCenteredPart(3, ChosenItems.chosenItems[3]);
        parts[4].GetComponent<SpriteRenderer>().sprite = Pickups.getNonCenteredPart(4, ChosenItems.chosenItems[4]);
        parts[5].GetComponent<SpriteRenderer>().sprite = Pickups.getNonCenteredPart(5, ChosenItems.chosenItems[5]);

        StartCoroutine(openLab());
    }

    IEnumerator openLab()
    {
        yield return new WaitForSeconds(0.5f);

        if(assemble)
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
