﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(!isLocalPlayer){
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space)){

            CmdFire();
        }

        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{

        //    Fire();
        //}


        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

	}

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    void CmdFire()
    {
        //Create the bullet grom the bullet prefab
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        //Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        //Spawn the bullets on the clients
        NetworkServer.Spawn(bullet);

        //Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);

    }

}

