using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAT : MonoBehaviour
{
    public GameObject flag;
    public Transform mainCamera;
    public bool isPuzzleViewOn = false;

    Transform presetTransform;
    // Start is called before the first frame update
    void Start()
    {
        presetTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPuzzleViewOn == false)
        {
            flag.SetActive(true);
            transform.LookAt(mainCamera);
        }

        else if (isPuzzleViewOn)
            flag.SetActive(false);
          
        if (Input.GetKeyDown(KeyCode.C))
        {
            isPuzzleViewOn = !isPuzzleViewOn;
        }
    }
}
