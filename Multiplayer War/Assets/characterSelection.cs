using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class characterSelection : MonoBehaviour {

    private GameObject[] avatars;
    private bool isLeft;
    private int index;

    private void Start()
    {


            //Transform child counts the number of childs in
            //the variable  and resizes it automaticaly
            avatars = new GameObject[transform.childCount];

            index = PlayerPrefs.GetInt("CharacterSelected");

            for (int i = 0; i < transform.childCount; i++)
            {
                avatars[i] = transform.GetChild(i).gameObject;
            }

            foreach (GameObject avatar in avatars)
            {
                avatar.SetActive(false);
            }


    }

    public void toggle(bool isLeft)
    {
        avatars[index].SetActive(false);

        if (isLeft)
        {
            index--;
            if (index < 0) 
            {
            index = avatars.Length - 1;
            }
            avatars[index].SetActive(true);
            
        }
        else
        {
            index++;
            if (index == avatars.Length)
            {
                index = 0;
            }
            avatars[index].SetActive(true);
            
        }
    }

    public void loadScene(int sceneIndex)
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene(sceneIndex);

    }
    public void showInitialPlayer(int index)
    {
        if (avatars[index]) 
        {
            avatars[index].SetActive(true);
        }
    }
}
