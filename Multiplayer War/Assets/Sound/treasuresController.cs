using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

    public class treasuresController :  NetworkBehaviour{

    public GameObject[] treasures;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < treasures.Length; i++)
        {           
            var treasureCollision = treasures[i].GetComponentInChildren<treasure>().collided;
            if (treasureCollision && treasures[i].GetComponentInChildren<treasure>().isClosed){
                treasures[i].GetComponentInChildren<treasure>().GetComponent<Animation>().Play("box_open");
                treasures[i].GetComponentInChildren<treasure>().isClosed = false;
            }
        }


    }


}
