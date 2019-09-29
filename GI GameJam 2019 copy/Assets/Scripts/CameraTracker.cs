using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
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
        nextPosition = 0.5f*(player.transform.position + player2.transform.position) + offset;
        nextPosition = new Vector3(0.5f * (player.transform.position.x + player2.transform.position.x),
            0.5f * (player.transform.position.y + player2.transform.position.y),
            Mathf.Min(player.transform.position.z, player2.transform.position.z)) + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, nextPosition, Time.deltaTime * movementSpeed);
            //player.transform.position + offset;
        //this.transform.LookAt(player.transform);
    }
}
