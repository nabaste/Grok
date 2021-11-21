using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ExperienceManager : MonoBehaviour
{
    public GameObject OVRCamera;
    public Game2Manager g2m;
    public GameCubeRotationTracker gcrt;
    public UnityEvent onGame1Completed, onGame2Completed, onCubeRotated;

    void Start()
    {
        
    }

    void Update()
    {
        if(g2m.isCompleted) 
        {
            onGame2Completed.Invoke(); //lo tengo que llamar una sola vez
            if(gcrt.isRotated)
            {
                onCubeRotated.Invoke(); //same
            }
        };

    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void togglePassthrough()
    {
        OVRCamera.GetComponent<OVRManager>().isInsightPassthroughEnabled = !OVRCamera.GetComponent<OVRManager>().isInsightPassthroughEnabled;
    }

    // public void onGame2Completed()
    // {
    //     Debug.Log("Game 2 completed");
    // }
}
