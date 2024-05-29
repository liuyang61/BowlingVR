using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    Rigidbody myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    Vector3 iniPos;
    Quaternion iniRot;

    public void InitializePinAtPosition()
    {
        iniPos = transform.position;
        iniRot = transform.rotation;
    }

    public IEnumerator ResetPosAndRot()
    {
        myRigidbody.isKinematic = true;

        myRigidbody.position = iniPos;
        myRigidbody.rotation = iniRot;

        yield return null;

        myRigidbody.isKinematic = false;
    }
}
