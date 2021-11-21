using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityManager : MonoBehaviour
{   
    private float changing;
    private Color activeColor = new Color(0.4f, 0.4f, 0.1f, 1f);
    private Color passiveColor = new Color(0.7f, 0.1f, 0.9f, 1f);

    void Awake()
    {
        changing = Mathf.Sin(Time.deltaTime);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        activeColor.r = changing;

        if(GetComponent<Renderer>().isVisible)
        {
            GetComponent<Renderer>().material.color = activeColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = passiveColor;
        }
    }
}
