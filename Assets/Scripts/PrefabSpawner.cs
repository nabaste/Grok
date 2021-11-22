using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject AirHockey, AlarmClock, Arcade, Backpack, Baseball, Books, CocaCola, Darksaber, Fidget, Opener, Keycard, Notebook, Notebook2, PacmanBlue, PacmanOrange, PenHolder, Pen, Rift, Sandtrooper, SpaceInvader1, SpaceInvader2, SpaceInvader2D, WaterBottle;
    public GameObject[] elements;
    private float XRangeLow = -2.5f;
    private float XRangeHigh = 2.5f;
    private float ZRangeLow = -2.5f;
    private float ZRangeGapLow = -1.3f;
    private float ZRangeGapHigh = 0.5f;
    private float ZRangeHigh = 2.5f;
    private bool isInFront;
    private float isInFrontDecider;
    private Quaternion iniRot = new Quaternion(0.3f, 0.4f, 0.2f, 0.7f);
    void Awake()
    {
        // isInFrontDecider = Random.Range(-1f, 1f);
        // isInFront = (isInFrontDecider >= 0) ? true : false;
    }
    void Start()
    {
        foreach(GameObject element in elements)
        {
            // Object.Instantiate(element, returnRandomPos(), iniRot);
            Object.Instantiate(element);
        }
    }   

    void Update()
    {
    }

    Vector3 ReturnRandomPos()
    {
        var x = Random.Range(XRangeLow, XRangeLow);
        var z = isInFront ? Random.Range(ZRangeGapHigh, ZRangeHigh) : Random.Range(ZRangeLow, ZRangeGapLow);
        return new Vector3(x, -1.5f, z);
    }
}
