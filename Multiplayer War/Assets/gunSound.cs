using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunSound : MonoBehaviour 
{


    public AudioSource audiosource;
    private AudioClip clip;
    public GameObject gunprefab;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            playShot();
        }
    }
    void playShot(){

        audiosource = gunprefab.GetComponent<AudioSource>();
        clip = audiosource.clip;
        audiosource.PlayOneShot(clip);
    }


}
