﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    
    public void loadScene(int sceneIndex){

        SceneManager.LoadScene(sceneIndex);

    }
}
