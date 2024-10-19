using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Popup : MonoBehaviour
{
    public Vector3 maxPopupSize;
    public GameObject popupObject;
    static int partCount = 0;
    private int bodyPart = 0;
    Sprite popupSprite = null;

    // options for each body part      (I need the sprites with a centered pivot for the popup, and sprites with the original pivot for the end scene)
    // public Sprite[] torso, head, rightArm, leftArm, rightLeg, leftLeg;
    // public Sprite[] torsoCentered, headCentered, rightArmCentered, leftArmCentered, rightLegCentered, leftLegCentered;

    // List<Sprite[]> torsoArrays, headArrays, rightArmArrays, leftArmArrays, rightLegArrays, leftLegArrays; 

    void Start()
    {
        partCount = 0;

        popupObject.SetActive(false);
    }

    public void popup()
    {
        // check which part
        switch(partCount) 
        {
            // pickup order order: right arm, left leg, torso, left arm, head, right leg
            // sorted order: head, torso, right arm, left arm, right leg, left leg
            case 0:
                bodyPart = 2;
                break;
            case 1:
                bodyPart = 5;
                break;
            case 2:
                bodyPart = 0;
                break;
            case 3:
                bodyPart = 3;
                break;
            case 4:
                bodyPart = 1;
                break;
            case 5:
                bodyPart = 4;
                break; 
        }

        // choose a random item of the correct body part
        int numOptions = Pickups.getPartArrayLength(bodyPart);
        int randomValue = Random.Range(0, numOptions);
        popupSprite = Pickups.getCenteredPart(bodyPart, randomValue);
        popupObject.GetComponent<SpriteRenderer>().sprite = popupSprite;

        // save the choice
        saveChosenItem(randomValue);

        // make it pop!
        StartCoroutine(popupIE());
        
        // next body part
        partCount++;
    }

    public IEnumerator popupIE()
    {
        // make the popup object very small
        popupObject.SetActive(true);
        popupObject.GetComponent<Transform>().localScale = new Vector3(0.01f, 0.01f, 1);

        // make it pop up
        popupObject.GetComponent<Transform>().DOScale(maxPopupSize*1.05f, 1);
        popupObject.GetComponent<Transform>().DORotate(new Vector3(0, 0, 720), 1, RotateMode.FastBeyond360);
        yield return new WaitForSeconds(1);
        popupObject.GetComponent<Transform>().DOScale(maxPopupSize, 0.2f);

        // close popup
        yield return new WaitForSeconds(1);
        popupObject.GetComponent<Transform>().DOScale(0.01f, 0.2f);
        yield return new WaitForSeconds(0.2f);
        popupObject.SetActive(false);

        // change scenes if all items are collected
        if(PlayerControls.allCollected)
        {
            PlayerControls.ChangeScenePhase2();
        }
    }

    public void saveChosenItem(int randomValue)
    {
        ChosenItems.setItem(bodyPart, randomValue);
    }
}
