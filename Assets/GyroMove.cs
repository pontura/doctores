using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroMove : MonoBehaviour
{    

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, 0);
        // Handle screen touches.
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved) {
                Vector2 pos = touch.deltaPosition;
                transform.Rotate(pos.y*0.1f, -pos.x*0.1f, 0);
            }
        }
    }
}
