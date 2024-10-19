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

    void Start()
    {
        items = new List<List<List<Sprite>>>();
        items.Add(new List<List<Sprite>> { torso, torsoCentered });
        items.Add(new List<List<Sprite>> { head, headCentered });
        items.Add(new List<List<Sprite>> { rightArm, rightArmCentered });
        items.Add(new List<List<Sprite>> { leftArm, leftArmCentered });
        items.Add(new List<List<Sprite>> { rightLeg, rightLegCentered });
        items.Add(new List<List<Sprite>> { leftLeg, leftLegCentered });
    }

    public static Sprite getNonCenteredPart(int bodyPart, int index)
    {
        return items[bodyPart][0][index];
    }
    
    public static Sprite getCenteredPart(int bodyPart, int index)
    {
        return items[bodyPart][1][index];
    }

    public static int getPartArrayLength(int bodyPart)
    {
        return items[bodyPart][0].Count;
    }
}
