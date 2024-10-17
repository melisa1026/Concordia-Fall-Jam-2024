using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animation : MonoBehaviour
{
    public GameObject anim;
    public GameObject bgd;
    public GameObject needlePoint;

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetActive(true);
        bgd.SetActive(true);
        //remove line
        needlePoint.GetComponent<LineRenderer>().positionCount = 0;
        needlePoint.GetComponent<LineRenderer>().enabled = false;
        StartCoroutine(NewScene());
    }

    public IEnumerator NewScene()
    {
        yield return new WaitForSeconds(3.2f);
        SceneManager.LoadScene("Operating Room");
    }

    }
