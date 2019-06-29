﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] float resPnt = -6;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < resPnt)
        {
            transform.position = new Vector3(0,2,0);
        }
    }
}
