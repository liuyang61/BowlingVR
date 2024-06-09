using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonControl_VR : MonoBehaviour
{
    public BowlingSimulation bowlingSimulation;

    public InputActionReference rightTrigger;
    public InputActionReference rightThumbstick;

    private bool rightTriggerDown = false;

    public float rotationSpeed = 30f; // degree per second

    public Transform cannonAxis;


    private void OnEnable()
    {
        rightTrigger.action.started += RightTriggerButtonPress;
    }

    private void OnDisable()
    {
        rightTrigger.action.started -= RightTriggerButtonPress;
    }

    public enum CannonRotateCommandState
    {
        none,
        goLeft,
        goRight
    }

    private CannonRotateCommandState commandState = CannonRotateCommandState.none;

    private void Update()
    {
        if (rightTriggerDown)
        {
            StartCoroutine(bowlingSimulation.LaunchRoutine());
        }

        Vector2 rightThumbstickValue = rightThumbstick.action.ReadValue<Vector2>();



        if (rightThumbstickValue.x < -0.5f)
        {
            commandState = CannonRotateCommandState.goLeft;
        }
        else if (rightThumbstickValue.x > 0.5f)
        {
            commandState = CannonRotateCommandState.goRight;
        }
        else
        {
            commandState = CannonRotateCommandState.none;
        }

        float currentRotateSpeed = 0;

        switch (commandState)
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



        //Debug.Log(rightThumbstickValue.ToString());

        ResetButtons();
    }

    public void RightTriggerButtonPress(InputAction.CallbackContext callbackContext)
    {
        rightTriggerDown = true;
    }

    private void ResetButtons()
    {
        rightTriggerDown = false;
    }
}
