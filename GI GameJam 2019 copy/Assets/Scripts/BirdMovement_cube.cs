using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement_cube : MonoBehaviour
{
    public Transform StartLocation;
    public Rigidbody rb;
    public float movementSpeed;
    public float JumpHeight;
    private bool onFloor;
    public Transform Level;

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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp(rb);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown(rb);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft(rb);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight(rb);
        }
        if(Input.GetKeyDown(KeyCode.RightShift) && onFloor)
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
        if (collision.gameObject.transform.IsChildOf(Level))
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
