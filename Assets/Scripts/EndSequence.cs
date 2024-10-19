using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSequence : MonoBehaviour
{
    public GameObject lightningTower, blackScreen;
    public Sprite darkTower, lightTower;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endSequence());
    }

    IEnumerator endSequence()
    {
        // show the operations room
        yield return new WaitForSeconds(2f);

        // show the lightning strike
        transform.position = new Vector3(50, 0, transform.position.z);
        yield return new WaitForSeconds(1.5f);
        lightningTower.GetComponent<SpriteRenderer>().sprite = lightTower;
        yield return new WaitForSeconds(0.1f);
        lightningTower.GetComponent<SpriteRenderer>().sprite = darkTower;
        yield return new WaitForSeconds(0.2f);
        lightningTower.GetComponent<SpriteRenderer>().sprite = lightTower;
        yield return new WaitForSeconds(0.1f);
        lightningTower.GetComponent<SpriteRenderer>().sprite = darkTower;
        yield return new WaitForSeconds(0.1f);
        lightningTower.GetComponent<SpriteRenderer>().sprite = lightTower;
        yield return new WaitForSeconds(0.1f);
        lightningTower.GetComponent<SpriteRenderer>().sprite = darkTower;
        yield return new WaitForSeconds(1);

        // go back to the operation room and flicker the lights
        transform.position = new Vector3(0, 0, transform.position.z);
        yield return new WaitForSeconds(1);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        blackScreen.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        blackScreen.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        blackScreen.SetActive(true);

        // have the eyes open in the light

        // go to the win screen
    }
}
