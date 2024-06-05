using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    public float rotationSpeed = 20f; // degree per second

    public Transform cannonAxis;

    public enum CannonRotateCommandState
    {
        none,
        goLeft,
        goRight
    }

    private CannonRotateCommandState commandState = CannonRotateCommandState.none;

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            commandState = CannonRotateCommandState.goLeft;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            commandState = CannonRotateCommandState.goRight;
        }
        else
        {
            commandState = CannonRotateCommandState.none;
        }

        float currentRotateSpeed = 0;

        switch(commandState)
        {
            case CannonRotateCommandState.none:
                break;

            case CannonRotateCommandState.goLeft:
                currentRotateSpeed = -rotationSpeed;
                break;

            case CannonRotateCommandState.goRight:
                currentRotateSpeed = rotationSpeed;
                break;
        }

        cannonAxis.Rotate(0, currentRotateSpeed * Time.deltaTime, 0, Space.World);
    }
}
