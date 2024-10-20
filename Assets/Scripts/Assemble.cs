using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Assemble : MonoBehaviour
{
    public GameObject[] parts;
    public GameObject assemblyLocation, whiteScreen;
    int partCount = 0;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("DButton"))
        {
            placePart();
        }
    }

    public void placePart()
    {
        if(partCount < 6)
        {
            parts[partCount].GetComponent<Transform>().DOMove(assemblyLocation.transform.position, 1);
            parts[partCount].GetComponent<Transform>().DORotate(new Vector3(0, 0, 0), 1);
            partCount++;
        }
        else
        {
            StartCoroutine(goToSewingScene());
        }
    }

    public IEnumerator goToSewingScene()
    {
        whiteScreen.GetComponent<SpriteRenderer>().DOFade(1, 1.5f);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Sewing");
    }
}
