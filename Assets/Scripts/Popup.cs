using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Popup : MonoBehaviour
{
    static int partCount = 0;

    public GameObject popupObject;

    // these lists have all the options for each body part
    public Sprite[] torso, head, rightArm, leftArm, rightLeg, leftLeg;
    
    // this is the same as the last one, but the sprites have centered pivot points
    public Sprite[] torsoCentered, headCentered, rightArmCentered, leftArmCentered, rightLegCentered, leftLegCentered;

    Sprite popupSprite = null;

    public Vector3 maxPopupSize;

    void Start()
    {
        popupObject.SetActive(false);
    }

    public void popup()
    {
        // decide which body part is being picked up
        Sprite[] optionsCentered = null;
        Sprite[] optionsNotCentered = null;

        switch(partCount) 
        {
            case 0:
                optionsNotCentered = rightArm;
                optionsCentered = rightArmCentered;
                break;
            case 1:
                optionsNotCentered = leftLeg;
                optionsCentered = leftLegCentered;
                break;
            case 2:
                optionsNotCentered = torso;
                optionsCentered = torsoCentered;
                break;
            case 3:
                optionsNotCentered = leftArm;
                optionsCentered = leftArmCentered;
                break;
            case 4:
                optionsNotCentered = head;
                optionsCentered = headCentered;
                break;
            case 5:
                optionsNotCentered = rightLeg;
                optionsCentered = rightLegCentered;
                break;
            
        }
            
        partCount++;

        if(optionsCentered != null)
        {
            // choose a random part + assign it to the popup object
            int numOptions = optionsCentered.Length;
            int randomValue = Random.Range(0, numOptions);
            popupSprite = optionsCentered[randomValue];
            popupObject.GetComponent<SpriteRenderer>().sprite = popupSprite;

            // make it pop!
            StartCoroutine(popupIE());
            
        }
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


    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            popup();
        }
    }
}
