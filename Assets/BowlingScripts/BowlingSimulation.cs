using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingSimulation : MonoBehaviour
{

    public Transform testVelocityDirection;
    public float testVelocityMagnitude;

    public Rigidbody testBowlingBall;

    public void Start()
    {
        StartCoroutine(PendTestLaunch());
    }


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
