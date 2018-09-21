using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class SelectOnInput : MonoBehaviour {

    public EventSystem EventSystem;
    public GameObject objectSelected;

    private bool buttonSelected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            EventSystem.SetSelectedGameObject(objectSelected);
            buttonSelected = true;

        }
		
	}

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
