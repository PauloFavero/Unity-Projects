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
            if (Input.GetKey(KeyCode.Mouse0))
            {
                CmdFire();
                anim.SetBool("isAttacking", true);
                anim.SetBool("isIdle", false);
                anim.SetBool("isWalking", false);
            }
            //Pause Game
            else if (Input.GetKeyDown(KeyCode.P))
            {
                Application.LoadLevel("mainMenuScene");
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 20.0f, ForceMode.Impulse);
                Debug.Log("Jump: ");
            }
            else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
            {
                var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
                var z = Input.GetAxis("Vertical") * Time.deltaTime * 7.0f;
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", true);
                anim.SetBool("isIdle", false);
                transform.Rotate(0, x, 0);
                transform.Translate(0, 0, z);
            }
            else{
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", true);
            }

            //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
            //var z = Input.GetAxis("Vertical") * Time.deltaTime * 7.0f;


            //transform.Rotate(0, x, 0);
            //transform.Translate(0, 0, z);

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

