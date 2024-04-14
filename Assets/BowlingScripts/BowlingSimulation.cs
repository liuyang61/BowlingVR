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

    public void Start()
    {
        StartCoroutine(PendTestLaunch());
    }

    // wait for 2 seconds and launch the ball
    IEnumerator PendTestLaunch()
    {
        yield return new WaitForSeconds(2f);

        testBowlingBall.isKinematic = false;
        //testBowlingBall.useGravity = true;
        yield return null;

        Launch(testVelocityDirection.forward * testVelocityMagnitude);
    }
    private void Launch(Vector3 initialVelcity)
    {
        testBowlingBall.AddForce(initialVelcity, ForceMode.VelocityChange);
    }
}
