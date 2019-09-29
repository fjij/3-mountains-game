using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBurning : MonoBehaviour
{
    // Start is called before the first frame update

	public Transform fireTransform;
	public GameObject normal;
	public GameObject glowing;
	public float BurnDuration = 15f;

	private bool lit = false;
	private float burnTimer = 0.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		// fire
		if (lit){
			burnTimer -= Time.deltaTime;
			if(burnTimer <= 0.0f){
				SetLit(false);
			}
		}
    }

	void SetLit(bool lit) {
		this.lit = lit;
		fireTransform.gameObject.SetActive(lit);
		if (lit){
			glowing.SetActive(true);
			normal.SetActive(false);
			this.burnTimer = BurnDuration;
		} else {
			glowing.SetActive(false);
			normal.SetActive(true);
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Fire") {
			SetLit(true);
		}
	}
}
