using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    [SerializeField] private Canvas canvas; // The canvas
    [SerializeField] private float zoomSpeed = 0.5f;        // The rate of change of the canvas scale factor

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // ... change the canvas size based on the change in distance between the touches.
            canvas.scaleFactor -= deltaMagnitudeDiff * zoomSpeed;

            // Make sure the canvas size never drops below 0.1
            canvas.scaleFactor = Mathf.Max(canvas.scaleFactor, 0.1f);
        }
    }

    //idée
    //double click = zoomin sur object? Redo = zoomout
    //click non followed = pop up closable
    //changer algo pinch = oskour
}