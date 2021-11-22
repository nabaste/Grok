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
    public UnityEvent onIntroCompleted, onGame1Completed, onGame2Completed, onCubeRotated, onClearHead, onClearHeadFinish;
    private float introLength = 45;
    private float game1Length = 90;
    private float failSoundLength = 3;
    private float clearHeadLength = 3;
    private float finalCubeInteractionLength = 5;

    void Start()
    {
        StartCoroutine(IntroInProgress());
    }

    void Update()
    {
        if (g2m.isCompleted)
        {
            onGame2Completed.Invoke(); //lo tengo que llamar una sola vez
            StartCoroutine(waitForFinalCubeInteraction());
            if (gcrt.isRotated)
            {
                // onCubeRotated.Invoke();
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
    IEnumerator waitForFailSound()
    {
        yield return new WaitForSeconds(failSoundLength);
        SceneManager.LoadScene(1);
    }
    IEnumerator clearHead()
    {
        onClearHead.Invoke();
        yield return new WaitForSeconds(clearHeadLength);
        onClearHeadFinish.Invoke();
    }
    IEnumerator waitForFinalCubeInteraction()
    {
        yield return new WaitForSeconds(finalCubeInteractionLength);
        onCubeRotated.Invoke();
    }
    public void BreathingPassthroughCycle()
    {
        StartCoroutine(clearHead());
    }
    public void RestartScene()
    {
        StartCoroutine(waitForFailSound());
    }
    public void OpenPassthrough()
    {
        OVRCamera.GetComponent<OVRManager>().isInsightPassthroughEnabled = true;
    }
    // public void ClosePassthrough()
    // {
    //     OVRCamera.GetComponent<OVRManager>().isInsightPassthroughEnabled = false;
    // }

    // public void EndExperience()
    // {
    //     SceneManager.LoadScene(1);
    // }
}
