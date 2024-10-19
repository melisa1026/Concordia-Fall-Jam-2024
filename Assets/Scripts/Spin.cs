using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spin : MonoBehaviour
{
    public bool isClockwise = true;

    // Start is called before the first frame update
    void Start()
    {
        if(isClockwise)
            transform.DORotate(new Vector3(0, 0, 360), 7f, RotateMode.FastBeyond360).SetRelative(true)
            .SetEase(Ease.Linear).SetLoops(-1);
        else
            transform.DORotate(new Vector3(0, 0, -360), 7f, RotateMode.FastBeyond360).SetRelative(true)
            .SetEase(Ease.Linear).SetLoops(-1);
    }
}
