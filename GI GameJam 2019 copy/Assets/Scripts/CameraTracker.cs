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

    public float viewChangeSpeed;
    // Start is called before the first frame update

    bool isPuzzleViewOn = false;
    Quaternion fixedRotation;
    Vector3 lastFrameLookingPoint;
    void Start()
    {
        this.transform.position = player.transform.position + offset;
        fixedRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 midPoint = new Vector3(0.5f * (player.transform.position.x + player2.transform.position.x),
            0.5f * (player.transform.position.y + player2.transform.position.y),
            Mathf.Min(player.transform.position.z, player2.transform.position.z));
        //nextPosition = 0.5f*(player.transform.position + player2.transform.position) + offset;


        if (isPuzzleViewOn)
        {
            nextPosition = new Vector3(0f, offset.magnitude, 0f);
            this.transform.LookAt(midPoint);
        }


        if (!isPuzzleViewOn)
        {
            nextPosition = midPoint + offset;
            transform.rotation = fixedRotation;
        }

        this.transform.position = Vector3.Lerp(this.transform.position, nextPosition, Time.deltaTime * movementSpeed);
        //player.transform.position + offset;
    }

    void IsPuzzleViewOn(bool temp)
    {
        isPuzzleViewOn = temp;
    }
}
