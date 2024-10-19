using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenItems : MonoBehaviour
{

    private static int[] chosenItems;

    void Start()
    {
        chosenItems = new int[6] {0, 0, 0, 0, 0, 0};
    }

    public static int getItem(int index)
    {
        if(chosenItems == null)
            return 0;
        else
        {
            return chosenItems[index];
        }
    }

    public static void setItem(int index, int value)
    {
        if(chosenItems != null)
        {
            chosenItems[index] = value;
        }
    }

}
