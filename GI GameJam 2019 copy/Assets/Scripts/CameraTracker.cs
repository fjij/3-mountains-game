using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    Vector3 nextPosition;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        nextPosition = player.transform.position + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, nextPosition, Time.deltaTime * movementSpeed);
            //player.transform.position + offset;
        //this.transform.LookAt(player.transform);
    }
}
