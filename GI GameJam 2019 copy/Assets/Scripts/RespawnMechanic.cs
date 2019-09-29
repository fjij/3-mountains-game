﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMechanic : MonoBehaviour
{
    private Vector3 startPosition;
	private Quaternion startRotation;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
		startRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y <= -20)
        {
            this.transform.position = startPosition;
			this.transform.rotation = startRotation;
			this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

	public void SetStartPosition(Vector3 startPosition){
		this.startPosition = startPosition;
	}
}
