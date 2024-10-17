using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawingNeedle : MonoBehaviour
{
    public GameObject needlePoint;

    private LineRenderer line;
    private Vector3 previousPosition;

    [SerializeField]
    private float minDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        previousPosition = transform.position;
        line.positionCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = needlePoint.GetComponent<Transform>().position;
        currentPosition.z = -1f;

        //to prevent line from starting in the middle
        if (previousPosition == transform.position)
        {
            line.SetPosition(0, currentPosition);
        }
        else
        {
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, currentPosition);
        }

        if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
        {
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, currentPosition);
            previousPosition = currentPosition;
        }
    }
}
