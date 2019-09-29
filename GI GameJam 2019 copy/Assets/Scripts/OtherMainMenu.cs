using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMainMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject endScreen;
    public BirdMovement b1;
    public BirdMovement bfat;

    private void Start()
    {
        endScreen.SetActive(false);
    }
    public void PlayGame()
    {
        //SceneManager.LoadScene(1);
        canvas.SetActive(false);
        b1.StartMoving();
        bfat.StartMoving();
    }
}
