using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PhaseScene : MonoBehaviour
{
    public string nextSceneName;
    public GameObject writing;
    public AudioSource soundEffect;

    void Start()
    {
        StartCoroutine(timedSceneChange());
    }

    public IEnumerator timedSceneChange()
    {
        Vector3 writingSize = writing.GetComponent<Transform>().localScale;
        writing.GetComponent<Transform>().localScale = writingSize*0.01f;
        yield return new WaitForSeconds(0.2f);

        writing.SetActive(true);

        // make the words animated in
        writing.GetComponent<Transform>().DOScale(writingSize*1.1f, 1);

        soundEffect.Play();
        yield return new WaitForSeconds(1);

        writing.GetComponent<Transform>().DOScale(writingSize, 0.3f);

        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(nextSceneName);
    }
}
