using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + offset;
        this.transform.LookAt(player.transform);
    }
}
