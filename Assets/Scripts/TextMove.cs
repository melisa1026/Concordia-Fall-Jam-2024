using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(transform.localScale * 0.95f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
