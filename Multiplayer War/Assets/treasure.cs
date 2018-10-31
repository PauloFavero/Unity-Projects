using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure : MonoBehaviour {

    public bool collided = false;
    public bool isClosed = true;
    public ParticleSystem paricleTreasureSystem;
	// Use this for initialization
	void Start () {
        isClosed = true;
        paricleTreasureSystem.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(!this.isClosed){
            paricleTreasureSystem.Play();
        }
	}

}
