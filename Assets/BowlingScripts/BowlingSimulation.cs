using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingSimulation : MonoBehaviour
{
    // this is a transform in the scene for usshi'fang to specify the initial velocity of the bowling ball.
    [Tooltip("Forward direction to be used as test initial direction.")]
    public Transform testVelocityDirection;
    [Tooltip("How fast the test ball will go?")]
    public float testVelocityMagnitude;

    public Rigidbody testBowlingBall;
    public Transform bowlingBallStartPositionPlaceholder;

    public GameObject bowlingBallModelFolder; // set this gameobject active or deactive to show/hide the model

    public void Start()
    {
        bowlingBallModelFolder.SetActive(false);
        testBowlingBall.isKinematic = true;
        testBowlingBall.position = bowlingBallStartPositionPlaceholder.position;

        StartCoroutine(PendTestLaunch());
    }

    // wait for 2 seconds and launch the ball
    IEnumerator PendTestLaunch()
    {
        yield return new WaitForSeconds(2f);

        testBowlingBall.position = bowlingBallStartPositionPlaceholder.position;
        yield return null;

        testBowlingBall.isKinematic = false;

        Launch(testVelocityDirection.forward * testVelocityMagnitude);
    }
    private void Launch(Vector3 initialVelcity)
    {
        bowlingBallModelFolder.SetActive(true);

        testBowlingBall.isKinematic = false;
        testBowlingBall.AddForce(initialVelcity, ForceMode.VelocityChange);
    }

    public PinsManager pinsManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            pinsManager.ResetAllPins();

            bowlingBallModelFolder.SetActive(false);
            testBowlingBall.isKinematic = true;

            StartCoroutine(PendTestLaunch());
        }
    }
}
