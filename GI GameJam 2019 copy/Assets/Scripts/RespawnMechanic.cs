﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMechanic : MonoBehaviour
{
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y <= -20)
        {
            this.transform.position = startPosition;
        }
    }
}
