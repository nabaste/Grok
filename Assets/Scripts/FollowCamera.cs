using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
public GameObject playerHeadCamera;
private Vector3 offset = new Vector3(0f, 0f, .5f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerHeadCamera.transform.position + offset;
    }
}
