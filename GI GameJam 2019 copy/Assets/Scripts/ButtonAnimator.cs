﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimator : MonoBehaviour
{
	public Animator animator;
	public AudioSource audioSource;
	public float MinimumMass = 2f;
    public GameObject endScreen;

	private bool pressed = false;

    public void OnTriggerEnter(Collider other) {
		Rigidbody rb = other.GetComponent<Rigidbody>();
		if (rb != null) {
			if (rb.mass > MinimumMass && !pressed) {
				animator.SetBool("on", true);
				Activate();
                endScreen.SetActive(true);
			}
		}
	}

	public void Activate() {
		pressed = true;
		audioSource.Play();
	}

	public bool GetActivated(){
		return pressed;
	}
}
