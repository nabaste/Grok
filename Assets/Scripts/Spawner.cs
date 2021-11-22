using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Rigidbody rb;
    private float XRangeLow = -2.5f;
    private float XRangeHigh = 2.5f;
    private float ZRangeLow = -2.5f;
    private float ZRangeGapLow = -1.3f;
    private float ZRangeGapHigh = 0.5f;
    private float ZRangeHigh = 2.5f;
    private float YRangeHigh = 2f;
    private float YRangeLow = -3f;
    private int Ydirection = 1;
    private Quaternion iniRot = new Quaternion(0.3f, 0.4f, 0.2f, 0.7f);
    private Vector3 iniPos = new Vector3(0.1f, 0.3f, 0.4f);
    private Vector3 iniTor = new Vector3(0.003f, 0.002f, 0.005f);
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(0f, Ydirection * 0.02f, 0f, ForceMode.Impulse);
        rb.AddTorque(iniTor, ForceMode.Impulse);
        ReevaluateDirection();
    }

    void ReevaluateDirection()
    {
        if(transform.position.y >= YRangeHigh)
        {
            Ydirection = -1;
        } else if (transform.position.y <= YRangeLow)
        {
            Ydirection = 1;
        }
    } 
}
