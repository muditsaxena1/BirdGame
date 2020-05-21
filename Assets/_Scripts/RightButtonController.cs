using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public BikeController bikeController;

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " Was Clicked.");
        bikeController.leftButtonPressed = false;
        bikeController.rightButtonPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        bikeController.rightButtonPressed = false;
    }
}
