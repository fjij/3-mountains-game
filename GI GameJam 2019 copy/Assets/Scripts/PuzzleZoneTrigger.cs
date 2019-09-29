using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleZoneTrigger : MonoBehaviour
{
    public Transform mainCamera;
    int chickenCount;
    bool isOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chicken")
        {
            chickenCount++;
			UpdateChickens();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Chicken"){
            chickenCount--;
			UpdateChickens();
		}
    }

    private void UpdateChickens(){
		isOn = chickenCount > 0;
        //mainCamera.SendMessage("IsPuzzleViewOn", isOn);
	}
}
