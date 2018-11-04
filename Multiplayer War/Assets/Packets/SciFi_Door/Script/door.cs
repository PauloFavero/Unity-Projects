using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	GameObject thedoor;
    GameObject[] buttons;

void OnTriggerEnter ( Collider obj  ){
	thedoor= GameObject.FindWithTag("SF_Door");
	thedoor.GetComponent<Animation>().Play("open");
}

void OnTriggerExit ( Collider obj  ){
	thedoor= GameObject.FindWithTag("SF_Door");
	thedoor.GetComponent<Animation>().Play("close");
}
}