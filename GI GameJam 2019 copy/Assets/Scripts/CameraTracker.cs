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
	Quaternion targetRotation;
    Vector3 lastFrameLookingPoint;

    public float zoomOutTimes = 2.5f;
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
            nextPosition = new Vector3(midPoint.x, zoomOutTimes * offset.magnitude, midPoint.z);
            targetRotation.eulerAngles = new Vector3(90, 0, 0);
        }


        if (!isPuzzleViewOn)
        {
            nextPosition = midPoint + offset;
            targetRotation = fixedRotation;
        }

        this.transform.position = Vector3.Lerp(this.transform.position, nextPosition, Time.deltaTime * movementSpeed);
		this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * movementSpeed);
        //player.transform.position + offset;

		if (Input.GetKeyDown(KeyCode.C)){
			isPuzzleViewOn = !isPuzzleViewOn;
		}
    }

    void IsPuzzleViewOn(bool temp)
    {
        isPuzzleViewOn = temp;
    }

}
