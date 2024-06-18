using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonControl_VR : MonoBehaviour
{
    public BowlingSimulation bowlingSimulation;

    public InputActionReference rightTrigger;
    public InputActionReference rightThumbstick;
    public InputActionReference resetButton;
    public InputActionReference changeBowlingBallButton;

    private bool rightTriggerDown = false;
    private bool resetButtonDown = false;
    private bool changeBowlingBallButtonDown = false;

    public float rotationSpeed = 30f; // degree per second

    public Transform cannonAxis;


    private void OnEnable()
    {
        rightTrigger.action.started += RightTriggerButtonPress;
        resetButton.action.started += ResetButtonPress;
        changeBowlingBallButton.action.started += ChangeBowlingBallButtonPress;
    }

    private void OnDisable()
    {
        rightTrigger.action.started -= RightTriggerButtonPress;
        resetButton.action.started -= ResetButtonPress;
        changeBowlingBallButton.action.started -= ChangeBowlingBallButtonPress;
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
            StartCoroutine(bowlingSimulation.LaunchRoutine(bowlingSimulation.cannonChoice.launchPlaceholders[bowlingSimulation.cannonChoice.cannonChoice].position));
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


        if(resetButtonDown)
        {
            bowlingSimulation.pinsManager.ResetAllPins();
            bowlingSimulation.testBowlingBall.isKinematic = true;
            bowlingSimulation.testBowlingBall.position = bowlingSimulation.ballFloatingPositionPlaceholder.position;
        }

        if(changeBowlingBallButtonDown)
        {
            bowlingSimulation.bowlingBallKeyboardChoice.IterateBowlingBallModel();
        }

        //Debug.Log(rightThumbstickValue.ToString());

        ResetButtons();
    }

    public void RightTriggerButtonPress(InputAction.CallbackContext callbackContext)
    {
        rightTriggerDown = true;
    }

    public void ResetButtonPress(InputAction.CallbackContext callbackContext)
    {
        resetButtonDown = true;
    }

    public void ChangeBowlingBallButtonPress(InputAction.CallbackContext callbackContext)
    {
        changeBowlingBallButtonDown = true;
    }

    private void ResetButtons()
    {
        rightTriggerDown = false;
        resetButtonDown = false;
        changeBowlingBallButtonDown = false;
    }
}
