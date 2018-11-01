using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerController_net : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public LoadSceneOnClick sceneManager;
    static NetworkAnimator anim;
    public bool isOnGround = true;
    public AudioSource jumpSound;
    public AudioSource walkSound;


    // Use this for initialization 
    void Start()
    {

        //Debug.Log("PLayer Name: " +  playerName);
        anim = GetComponent<NetworkAnimator>();
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
                anim.SetTrigger("attack");
            }
            //Pause Game
            else if (Input.GetKeyDown(KeyCode.P))
            {
                Application.LoadLevel("mainMenuScene");
            }
            else if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 50.0f, ForceMode.Impulse);
                Debug.Log("Jump: ");
                jumpSound.PlayOneShot(jumpSound.clip);
                isOnGround = false;
            }
            else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
            {
                if(!walkSound.isPlaying)
                    walkSound.PlayOneShot(walkSound.clip);
                anim.SetTrigger("walk");

            }
            else{
                anim.SetTrigger("idle");
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
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 20;

        //Spawn the bullets on the clients
        NetworkServer.Spawn(bullet);

        //Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        var objectCol = collision.gameObject;
        var button = objectCol.GetComponent<buttonContact>();

        var treasure = objectCol.GetComponent<treasure>();


        if (button != null)
        {
            button.buttonPressed = true;
        }

        if (treasure != null)
        {
            treasure.collided = true;
        }

        if(objectCol.gameObject.name == "Terrain"){

            isOnGround = true;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        var objectCol = collision.gameObject;
        var button = objectCol.GetComponent<buttonContact>();
        if (button != null){
            button.buttonPressed = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {

        var objectCol = collision.gameObject;
        var button = objectCol.GetComponent<buttonContact>();
        var treasure = objectCol.GetComponent<treasure>();
        if (button != null)
        {
            button.buttonPressed = false;
        }

        if (treasure != null)
        {
            treasure.collided = false;
            treasure.isClosed = true;
        }
    }

}

