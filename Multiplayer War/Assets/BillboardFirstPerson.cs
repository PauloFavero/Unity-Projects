﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardFirstPerson : MonoBehaviour
{
    public Camera firstPersonCamera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(firstPersonCamera.transform);

    }
}
