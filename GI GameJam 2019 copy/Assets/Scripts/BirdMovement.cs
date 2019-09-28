using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public Transform StartLocation;
    public Rigidbody rb;
    public float movementSpeed;
    public float JumpHeight;
    private bool onFloor;

    // Start is called before the first frame update
    void Start()
    {
        rb.transform.position = StartLocation.position;
        rb.velocity = new Vector3(0f, 0f, 0f);
        onFloor = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Detectors
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp(rb);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveDown(rb);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft(rb);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight(rb);
        }
        if(Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            onFloor = false;
            Jump(rb);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x * 0.9f, rb.velocity.y, rb.velocity.z * 0.9f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Floor"))
        {
            onFloor = true;
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
        rb.velocity = new Vector3(rb.velocity.x, JumpHeight, rb.velocity.z);
    }
}
