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

	private KeyCode[] upKey = {KeyCode.W, KeyCode.UpArrow};
	private KeyCode[] downKey = {KeyCode.S, KeyCode.DownArrow};
	private KeyCode[] leftKey = {KeyCode.A, KeyCode.LeftArrow};
	private KeyCode[] rightKey = {KeyCode.D, KeyCode.RightArrow};
	private KeyCode[] jumpKey = {KeyCode.Space, KeyCode.RightShift};

	private bool lit = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.transform.position = StartLocation.position;
        rb.velocity = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
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
        if(Input.GetKeyDown(jumpKey[playerIndex]) && isGrounded())
        {
            Jump(rb);
        }
    }
	private bool isGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f);
	}

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x * 0.9f, rb.velocity.y, rb.velocity.z * 0.9f);
    }

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Fire") {
			SetLit(true);
		}
	}

	void SetLit(bool lit) {
		if (lit != this.lit){
			this.lit = lit;
			fireTransform.gameObject.SetActive(lit);
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
