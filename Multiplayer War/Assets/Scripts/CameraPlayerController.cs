using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraPlayerController : NetworkBehaviour
{
    public Camera[] cameras;
    public int currentCameraIndex;
    public Canvas HUDFirstPerson;
    public Canvas HUDThirdPerson;
    public Canvas HUDOverView;

    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            currentCameraIndex = 0;

            //Turn all cameras off, except the first default one
            for (int i = 1; i < cameras.Length; i++)
            {
                cameras[i].gameObject.SetActive(false);
            }

            //If any cameras were added to the controller, enable the first one
            if (cameras.Length > 0)
            {
                cameras[0].gameObject.SetActive(true);
                Debug.Log("Camera with name: " + cameras[0].name + ", is now enabled");

                setHUD(cameras[0].name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            //If the c button is pressed, switch to the next camera
            //Set the camera at the current index to inactive, and set the next one in the array to active
            //When we reach the end of the camera array, move back to the beginning or the array.
            if (Input.GetKeyDown(KeyCode.C))
            {
                currentCameraIndex++;
                Debug.Log("C button has been pressed. Switching to the next camera");
                if (currentCameraIndex < cameras.Length)
                {
                    cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                    cameras[currentCameraIndex].gameObject.SetActive(true);
                    Debug.Log("Camera with name: " + cameras[currentCameraIndex].name + ", is now enabled");
                }
                else
                {
                    cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                    currentCameraIndex = 0;
                    cameras[currentCameraIndex].gameObject.SetActive(true);
                    Debug.Log("Camera with name: " + cameras[currentCameraIndex].name + ", is now enabled");
                }

                setHUD(cameras[currentCameraIndex].name);
            }
           
        }



    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
    }
    public void setHUD(string cameraName)
    {
        Debug.Log(cameraName);
        switch (cameraName)
        {

            case "FirstPerson":
                HUDFirstPerson.GetComponent<Canvas>().enabled = true;
                HUDThirdPerson.GetComponent<Canvas>().enabled = false;
                HUDOverView.GetComponent<Canvas>().enabled = false;
                break;
            case "ThirdPerson":
                HUDFirstPerson.GetComponent<Canvas>().enabled = false;
                HUDThirdPerson.GetComponent<Canvas>().enabled = true;
                HUDOverView.GetComponent<Canvas>().enabled = false;
                break;
            case "OverViewCamera":
                HUDFirstPerson.GetComponent<Canvas>().enabled = false;
                HUDThirdPerson.GetComponent<Canvas>().enabled = false;
                HUDOverView.GetComponent<Canvas>().enabled = true;
                break;
        }
    }
}