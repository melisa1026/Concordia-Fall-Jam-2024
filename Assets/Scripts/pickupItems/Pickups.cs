using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    /*
        Index order:
            0. torso
            1. head
            2. right arm
            3. left arm
            4. right leg
            5. left leg
    */
    public List<Sprite> torso, head, rightArm, leftArm, rightLeg, leftLeg;
    public List<Sprite> torsoCentered, headCentered, rightArmCentered, leftArmCentered, rightLegCentered, leftLegCentered;

    // format: {{cuncentered, cenetered}, {cuncentered, cenetered}}
    public static List<List<List<Sprite>>> items;
    public static bool isInitialized = false;

    void Start()
    {
        if(torso != null)
        {
            isInitialized = true;

            items = new List<List<List<Sprite>>>();
            items.Add(new List<List<Sprite>> { torso, torsoCentered });
            items.Add(new List<List<Sprite>> { head, headCentered });
            items.Add(new List<List<Sprite>> { rightArm, rightArmCentered });
            items.Add(new List<List<Sprite>> { leftArm, leftArmCentered });
            items.Add(new List<List<Sprite>> { rightLeg, rightLegCentered });
            items.Add(new List<List<Sprite>> { leftLeg, leftLegCentered });
        }
    }

    public static Sprite getNonCenteredPart(int bodyPart, int index)
    {
        if(isInitialized)
            return items[bodyPart][0][index];
        else 
            return null;
    }
    
    public static Sprite getCenteredPart(int bodyPart, int index)
    {
        if(isInitialized)
            return items[bodyPart][1][index];
        else 
            return null;
    }

    public static int getPartArrayLength(int bodyPart)
    {
        if(isInitialized)
            return items[bodyPart][0].Count;
        else
            return 0;
    }
}
