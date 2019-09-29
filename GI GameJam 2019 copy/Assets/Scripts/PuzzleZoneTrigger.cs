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
            isOn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Chicken")
            chickenCount--;
    }

    private void Update()
    {
        if (chickenCount == 0)
        {
            isOn = false;
        }
        mainCamera.SendMessage("IsPuzzleViewOn", isOn);
    }
}