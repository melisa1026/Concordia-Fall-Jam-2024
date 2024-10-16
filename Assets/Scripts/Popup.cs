using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Popup : MonoBehaviour
{
    public Vector3 maxPopupSize;
    public GameObject popupObject;
    static int partCount = 0;
    Sprite popupSprite = null;

    // options for each body part      (I need the sprites with a centered pivot for the popup, and sprites with the original pivot for the end scene)
    public Sprite[] torso, head, rightArm, leftArm, rightLeg, leftLeg;
    public Sprite[] torsoCentered, headCentered, rightArmCentered, leftArmCentered, rightLegCentered, leftLegCentered;

    List<Sprite[]> torsoArrays, headArrays, rightArmArrays, leftArmArrays, rightLegArrays, leftLegArrays; 

    void Start()
    {
        popupObject.SetActive(false);

        torsoArrays = new List<Sprite[]> { torso, torsoCentered };
        headArrays = new List<Sprite[]> { head, headCentered };
        rightArmArrays = new List<Sprite[]> { rightArm, rightArmCentered };
        leftArmArrays = new List<Sprite[]> { leftArm, leftArmCentered };
        rightLegArrays = new List<Sprite[]> { rightLeg, rightLegCentered };
        leftLegArrays = new List<Sprite[]> { leftLeg, leftLegCentered };
    }

    public void popup()
    {

        // decide which body part is being picked up
        List<Sprite[]> options = null;
        switch(partCount) 
        {
            case 0:
                options = rightArmArrays;
                break;
            case 1:
                options = leftLegArrays;
                break;
            case 2:
                options = torsoArrays;
                break;
            case 3:
                options = leftArmArrays;
                break;
            case 4:
                options = headArrays;
                break;
            case 5:
                options = rightLegArrays;
                break; 
        }
        partCount++;

        if(options != null)
        {
            // choose a random part 
            int numOptions = options[1].Length;
            int randomValue = Random.Range(0, numOptions);
            popupSprite = options[1][randomValue];
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

        // close popup
        yield return new WaitForSeconds(1);
        popupObject.GetComponent<Transform>().DOScale(0.01f, 0.2f);
        yield return new WaitForSeconds(0.2f);
        popupObject.SetActive(false);

    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            popup();
        }
    }
}
