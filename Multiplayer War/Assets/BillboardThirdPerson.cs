using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : CameraPlayerController
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Camera with name: " + cameras[currentCameraIndex].name + ", is now enabled to Billboard");
        transform.LookAt(cameras[currentCameraIndex].transform);

    }
}
