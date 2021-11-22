using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject VO1, VO2, VO3, VO4, Coke;
    private float initialLoadingTime = 8;
    private float VO1Duration = 29;
    private float VO2Duration = 20;
    private float VO3Duration = 49;
    private float VO4Duration = 30;

    void Start()
    {
        StartCoroutine(waitForLoading());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator waitForLoading()
    {
        yield return new WaitForSeconds(initialLoadingTime);
        FirstSounds();
    }
    IEnumerator waitForVO2()
    {
        yield return new WaitForSeconds(VO2Duration);
        WhatIsThatButtonVO();
    }
    IEnumerator waitForVO3()
    {
        yield return new WaitForSeconds(VO3Duration);
        MakeItStopVO();
    }

    void FirstSounds()
    {
        VO1.GetComponent<AudioSource>().Play();
        Coke.GetComponent<AudioSource>().Play();
        Coke.GetComponent<AudioSource>().volume = 0.5f;
    }

    public void WhoCaresVO()
    {
        StartCoroutine(waitForVO2());
        VO2.GetComponent<AudioSource>().Play();
    }

    void WhatIsThatButtonVO()
    {
        StartCoroutine(waitForVO3());
        VO3.GetComponent<AudioSource>().Play();
    }

    void MakeItStopVO()
    {
        VO4.GetComponent<AudioSource>().Play();
    }
}
