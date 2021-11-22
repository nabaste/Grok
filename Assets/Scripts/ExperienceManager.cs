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
    public UnityEvent onIntroCompleted, onGame1Completed, onGame2Completed, onCubeRotated;
    private float introLength = 35;
    private float game1Length = 90;

    void Start()
    {
        StartCoroutine(IntroInProgress());
    }

    void Update()
    {
        if (g2m.isCompleted)
        {
            onGame2Completed.Invoke(); //lo tengo que llamar una sola vez
            if (gcrt.isRotated)
            {
                onCubeRotated.Invoke(); //same
            }
        };

    }

    IEnumerator IntroInProgress()
    {
        Debug.Log("Started intro at: " + Time.time);
        yield return new WaitForSeconds(introLength);
        onIntroCompleted.Invoke();
        Debug.Log("Finished intro at: " + Time.time);
        StartCoroutine(Game1InProgress());
    }
        IEnumerator Game1InProgress()
    {
        Debug.Log("Started game1 at: " + Time.time);
        yield return new WaitForSeconds(game1Length);
        onGame1Completed.Invoke();
        Debug.Log("Finished game1 at: " + Time.time);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void TogglePassthrough()
    {
        OVRCamera.GetComponent<OVRManager>().isInsightPassthroughEnabled = !OVRCamera.GetComponent<OVRManager>().isInsightPassthroughEnabled;
    }

    // public void onGame2Completed()
    // {
    //     Debug.Log("Game 2 completed");
    // }
}
