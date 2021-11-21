using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCubeRotationTracker : MonoBehaviour
{
    private Quaternion desiredRotation = new Quaternion(); //invoke
    private GameObject[] toGrayOut;
    private GameObject[] toGreenOut;
    public bool isRotated = false;
    private float percentangeOfDesiredRotationAchieved; 
    void Start()
    {
        toGrayOut =  GameObject.FindGameObjectsWithTag("toGrayOut");
        toGreenOut =  GameObject.FindGameObjectsWithTag("toGreenOut");

        Debug.Log(toGrayOut);
        Debug.Log(toGreenOut);

    }

    void Update()
    {   
        // percentangeOfDesiredRotationAchieved = transform.rotation; //matemáticaloca
        checkRotation();
        interpolateMaterials(percentangeOfDesiredRotationAchieved);
    }
    void checkRotation()
    {
        if(transform.rotation == desiredRotation) isRotated = true; //add threshhold
    }

    void interpolateMaterials(float percentage)
    {

    }
}
