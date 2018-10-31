using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ExitController : NetworkBehaviour {

    public GameObject door;
    public  GameObject[] Buttons;
    public bool doorIsClosed;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        var b1 = Buttons[0].GetComponent<buttonContact>().buttonPressed;
        var b2 = Buttons[1].GetComponent<buttonContact>().buttonPressed;

        if (b1 && b2 && doorIsClosed){
            doorIsClosed = false;
            door.GetComponent<Animation>().Play("open");
        }
        //else if (!doorIsClosed ){
        //    doorIsClosed = true;
        //    door.GetComponent<Animation>().Play("close");
        //}
    }

}
