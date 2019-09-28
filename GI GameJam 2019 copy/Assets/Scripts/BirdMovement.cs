using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public Transform StartLocation;
    public Rigidbody rb;
    public float movementSpeed;
    public float JumpHeight;
	public int playerIndex = 0;
	public AudioSource audioSource;
	public Transform fireTransform;
	public float BurnDuration = 15f;

	private KeyCode[] upKey = {KeyCode.W, KeyCode.UpArrow};
	private KeyCode[] downKey = {KeyCode.S, KeyCode.DownArrow};
	private KeyCode[] leftKey = {KeyCode.A, KeyCode.LeftArrow};
	private KeyCode[] rightKey = {KeyCode.D, KeyCode.RightArrow};
	private KeyCode[] jumpKey = {KeyCode.Space, KeyCode.RightShift};

	private bool lit = false;
	private float burnTimer = 0.0f;
	private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.transform.position = StartLocation.position;
        rb.velocity = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
		grounded = isGrounded();
        //Movement Detectors
        if (Input.GetKey(upKey[playerIndex]))
        {
            MoveUp(rb);
        }
        if (Input.GetKey(downKey[playerIndex]))
        {
            MoveDown(rb);
        }
        if (Input.GetKey(leftKey[playerIndex]))
        {
            MoveLeft(rb);
        }
        if (Input.GetKey(rightKey[playerIndex]))
        {
            MoveRight(rb);
        }
        if(Input.GetKeyDown(jumpKey[playerIndex]) && grounded)
        {
			if (playerIndex == 0) {
	            Jump(rb);
			}
        }
		// fire
		if (lit){
			burnTimer -= Time.deltaTime;
			if(burnTimer <= 0.0f){
				SetLit(false);
			}
		}
    }
	private bool isGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
	}

    private void FixedUpdate()
    {
		if (grounded) {
			ApplyFriction(0.8f);
		}
    }

	private void ApplyFriction(float f) {
		rb.velocity = new Vector3(rb.velocity.x * f, rb.velocity.y, rb.velocity.z * f);
	}

	void OnCollisionEnter(Collision collision) {
		if (playerIndex == 0 && collision.gameObject.tag == "Fire") {
			SetLit(true);
		}
	}

	void SetLit(bool lit) {
		this.lit = lit;
		fireTransform.gameObject.SetActive(lit);
		if (lit){
			this.burnTimer = BurnDuration;
		}
	}

    //Movement Functions
    void MoveUp(Rigidbody rb)
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, movementSpeed);
    }
    void MoveDown(Rigidbody rb)
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -movementSpeed);
    }
    void MoveLeft(Rigidbody rb)
    {
        rb.velocity = new Vector3(-movementSpeed, rb.velocity.y, rb.velocity.z);
    }
    void MoveRight(Rigidbody rb)
    {
        rb.velocity = new Vector3(movementSpeed, rb.velocity.y, rb.velocity.z);
    }
    void Jump(Rigidbody rb)
    {
		audioSource.Play();
        rb.velocity = new Vector3(rb.velocity.x, JumpHeight, rb.velocity.z);
    }
}
