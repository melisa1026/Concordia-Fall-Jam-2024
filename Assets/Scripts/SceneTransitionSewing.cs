using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SceneTransitionSewing : MonoBehaviour
{
    public GameObject whiteScreen;

    void Start()
    {
        whiteScreen.GetComponent<Transform>().DOScale(new Vector3(whiteScreen.GetComponent<Transform>().localScale.x, 0, 1), 1f);
    }
}
