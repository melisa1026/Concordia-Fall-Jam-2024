using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HToSave : MonoBehaviour
{
    public TMP_InputField input;
    public GameObject HToGoHome;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("DButton"))
        {
            // save the name and values to the database

            // values as an integer
            string concatenatedDigits = "";
            for(int i = 0; i < ChosenItems.getItems().Length; i++)
            {
                // prevent leading 0s
                int digit = ChosenItems.getItems()[i];
                if(i==0 && ChosenItems.getItems()[i]==0)
                    digit = 6;

                concatenatedDigits += digit.ToString();
            }
            int value = int.Parse(concatenatedDigits);

            Leaderboard.SetLeaderboardEntry(input.text, value);

            StartCoroutine(loadASecond());

        }

    }

    IEnumerator loadASecond()
    {
        yield return new WaitForSeconds(2);
        
        HToGoHome.SetActive(true);
        gameObject.SetActive(false);
    }
}
