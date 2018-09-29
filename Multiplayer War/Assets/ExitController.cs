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
		
	}

    private void OnCollisionEnter(Collision collision)
    {
    

    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.contacts.Equals(Buttons[0]) && collision.contacts.Equals(Buttons[1]))
        {
            door.GetComponent<Animation>().Play("open");
        }

    }

    private void OnCollisionExit(Collision collision)
    {
            if (collision.contacts.Equals(Buttons[0]) || collision.contacts.Equals(Buttons[1]))
        {
            door.GetComponent<Animation>().Play("close");
        }
    }


}
