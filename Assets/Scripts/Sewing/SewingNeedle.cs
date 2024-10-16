using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewingNeedle : MonoBehaviour
{

    private float x;
    private float y;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x, y, 0);

        x = Input.GetAxisRaw("Horizontal") * speed;
        y = Input.GetAxisRaw("Vertical") * speed;
    }
}
