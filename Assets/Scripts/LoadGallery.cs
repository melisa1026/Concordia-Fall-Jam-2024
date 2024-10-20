using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadGallery : MonoBehaviour
{
    public GameObject loadingScreen;
    public TMP_Text text1, text2, text3;
    public GameObject monster1, monster2, monster3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadScreen());
    }
    
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("DButton"))
        {
            StartCoroutine(loadScreen());
        }
    }


    // shows 3 random gallery items
    public void viewMore()
    {
        StartCoroutine(loadScreen());
    }

    // this is definitely not good practice but it's midnight and the last day of the jam and I can't think straight
    IEnumerator loadScreen()
    {
        loadingScreen.SetActive(true);

        // get the leaderboard elements
        Leaderboard.GetLeaderboard();

        while(Leaderboard.GetData() == null || Leaderboard.GetData().Count == 0) {
            yield return new WaitForSeconds(1);
        }

        loadingScreen.SetActive(false);

        loadItems();
    }

    void loadItems()
    {
        List<(string, int)> data = Leaderboard.GetData();

        text2.SetText(data[1].Item1);
        text3.SetText(data[2].Item1);

        // choose 3 random ones
        // 1:
        int randomValue = Random.Range(0, data.Count);
        text1.SetText(data[randomValue].Item1);
        monster1.GetComponent<LoadCharacter>().loadCharacter(data[randomValue].Item2);
        data.RemoveAt(randomValue);

        Debug.Log(randomValue + " " + data.Count);

        // 2:
        randomValue = Random.Range(0, data.Count);
        text2.SetText(data[randomValue].Item1);
        monster2.GetComponent<LoadCharacter>().loadCharacter(data[randomValue].Item2);
        data.RemoveAt(randomValue);

        Debug.Log(randomValue + " " + data.Count);

        // 3:
        randomValue = Random.Range(0, data.Count);
        text3.SetText(data[randomValue].Item1);
        monster3.GetComponent<LoadCharacter>().loadCharacter(data[randomValue].Item2);
        data.RemoveAt(randomValue);

        Debug.Log(randomValue + " " + data.Count);
    }
}
