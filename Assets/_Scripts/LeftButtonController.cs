using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public BikeController bikeController;

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " Was Clicked.");
        bikeController.rightButtonPressed = false;
        bikeController.leftButtonPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " Was Released.");
        bikeController.leftButtonPressed = false;
    }
}
