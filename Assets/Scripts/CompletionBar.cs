using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionBar : MonoBehaviour
{
    public GameObject bar;
    public float percentToIncrement = 10;

    void Start()
    {
        // start with the health bar at 0
        ResetBar();
    }

    // reset the bar to 0
    public void ResetBar()
    {
        bar.GetComponent<Transform>().localScale = new Vector3(0, bar.GetComponent<Transform>().localScale.y, 1);
    }

    // increase the health bar
    // returns true if the bar is full
    public bool IncreaseBar()
    {
        Vector3 currentScale = bar.GetComponent<Transform>().localScale;
        bar.GetComponent<Transform>().localScale = new Vector3(currentScale.x+percentToIncrement/100, bar.GetComponent<Transform>().localScale.y, 1);

        if(bar.GetComponent<Transform>().localScale.x >= 1)
        {
            ResetBar();
            return true;
        }
        else
            return false;
            
    }
}
