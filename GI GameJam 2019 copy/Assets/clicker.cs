using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clicker : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource audioz;

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioz.Play();
    }

}
