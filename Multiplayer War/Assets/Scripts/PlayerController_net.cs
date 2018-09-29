using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerController_net : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public LoadSceneOnClick sceneManager;
    static Animator anim;

   
    // Use this for initialization 
    void Start()
    {

        //Debug.Log("PLayer Name: " +  playerName);
        anim = GetComponent<Animator>();
        if (anim == null)
            Debug.Log("anim nula");
    }

    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {

        if (isLocalPlayer)
        {
            //Fire 
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                CmdFire();
                anim.SetBool("isAttacking", true);
                anim.SetBool("isIdle", false);
                anim.SetBool("isWalking", false);
            }
            //Pause Game
            if (Input.GetKeyDown(KeyCode.P))
            {
                Application.LoadLevel("mainMenuScene");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 20.0f, ForceMode.Impulse);
                Debug.Log("Jump: ");
            }
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 7.0f;

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
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;

        //Spawn the bullets on the clients
        NetworkServer.Spawn(bullet);

        //Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);

    }

   
}

