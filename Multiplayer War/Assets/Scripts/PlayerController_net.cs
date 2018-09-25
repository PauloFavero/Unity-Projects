using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerController_net : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    [SyncVar]
    public string playerName;

    public LoadSceneOnClick sceneManager;




	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update()
    {

        if (isLocalPlayer)
        {
            //Fire 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CmdFire();
            }
            //Pause Game
            if (Input.GetKeyDown(KeyCode.P))
            {
                Application.LoadLevel("mainMenuScene");
            }
        
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 200.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);

        }
    }

    public override void OnStartLocalPlayer()
    {
        //GetComponent<MeshRenderer>().material.color = Color.blue;
        //TODO: Write here onlobbyplayer to add custom prefab
        
    }

    [Command]
    void CmdFire()
    {
        //Create the bullet grom the bullet prefab
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        //Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;

        //Spawn the bullets on the clients
        NetworkServer.Spawn(bullet);

        //Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);

    }

    void setPlayerName(string Name){

       
    }

}

