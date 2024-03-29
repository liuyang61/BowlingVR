using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    Rigidbody myRigidbody;
    MeshCollider myMeshCollider;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myMeshCollider = GetComponent<MeshCollider>();

        myRigidbody.isKinematic = true;
    }

    Vector3 iniPos;
    Quaternion iniRot;

    public void InitializePinAtPosition()
    {
        iniPos = transform.position;
        iniRot = transform.rotation;

        myRigidbody.isKinematic = false;

        StartCoroutine(PendResetPosAndRot());
    }

    IEnumerator PendResetPosAndRot()
    {
        yield return null;

        myRigidbody.position = iniPos;
        myRigidbody.rotation = iniRot;
    }
}
