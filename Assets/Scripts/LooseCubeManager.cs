using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LooseCubeManager : MonoBehaviour
{
    public bool isOnPosition = false;
    public UnityEvent onPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == tag)
        {
            isOnPosition = true;
            onPosition.Invoke();
        }
    }
}
