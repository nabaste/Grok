using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Manager : MonoBehaviour
{
    public GameObject redLoose, greenLoose, yellowLoose;
    private Vector3 redIniPos = new Vector3(-0.010025f, 0.01003f, -0.0100292f);
    private Vector3 greenIniPos = new Vector3(-0.010025f, -0.01002f, -0.0100292f); //polémico
    private Vector3 yellowIniPos = new Vector3(0.010025f, -0.01002f, -0.0100292f);
    private Quaternion iniRot = new Quaternion();
    private Dictionary<GameObject, Vector3> initialLocations = new Dictionary<GameObject, Vector3>();
    public bool isCompleted = false;
    private int matches = 0;

    void Start()
    {
        initialLocations.Add(redLoose, redIniPos);
        initialLocations.Add(greenLoose, greenIniPos);
        initialLocations.Add(yellowLoose, yellowIniPos);
    }
    void Update()
    {
        if (!isCompleted) checkPositions();
    }
    void checkPositions()
    {
        if (matches == 3) isCompleted = true;

    }
    void snapIntoPosition(GameObject cube, Vector3 iniPos)
    {
        cube.transform.position = iniPos;
        cube.transform.rotation = iniRot;
    }

    public void onGreenPositioned()
    {
        snapIntoPosition(greenLoose, greenIniPos);
        matches++;
    }
    public void onRedPositioned()
    {
        snapIntoPosition(redLoose, redIniPos);
        matches++;
    }
    public void onYellowPositioned()
    {
        snapIntoPosition(yellowLoose, yellowIniPos);
        matches++;
    }
}
