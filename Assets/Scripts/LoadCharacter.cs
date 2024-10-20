using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCharacter : MonoBehaviour
{
    public GameObject torso, head, rightArm, leftArm, rightLeg, leftLeg;

    public void loadCharacter(int values)
    {
        var digits = new List<int>();
        while (values > 0)
        {
            digits.Add(values % 10);
            values /= 10;
        }

        digits.Reverse();

        // torso
        if(Pickups.getNonCenteredPart(0, ChosenItems.getItem(0)) != null)
        {
            // the number 010000 saves as 10000, so I replaced leading 0s with 6
            int digit = digits[0];
            if(digit == 6)
                digit = 1;

            torso.GetComponent<Image>().sprite = Pickups.getNonCenteredPart(0, digit);
        }
            

        // head
        if(Pickups.getNonCenteredPart(0, ChosenItems.getItem(1)) != null)
            head.GetComponent<Image>().sprite = Pickups.getNonCenteredPart(1, digits[1]);

        // right arm
        if(Pickups.getNonCenteredPart(0, ChosenItems.getItem(2)) != null)
            rightArm.GetComponent<Image>().sprite = Pickups.getNonCenteredPart(2, digits[2]);

        // left arm
        if(Pickups.getNonCenteredPart(0, ChosenItems.getItem(3)) != null)
            leftArm.GetComponent<Image>().sprite = Pickups.getNonCenteredPart(3, digits[3]);

        // right leg
        if(Pickups.getNonCenteredPart(0, ChosenItems.getItem(4)) != null)
            rightLeg.GetComponent<Image>().sprite = Pickups.getNonCenteredPart(4, digits[4]);

        // left leg
        if(Pickups.getNonCenteredPart(0, ChosenItems.getItem(5)) != null)
            leftLeg.GetComponent<Image>().sprite = Pickups.getNonCenteredPart(5, digits[5]);
    }
}
