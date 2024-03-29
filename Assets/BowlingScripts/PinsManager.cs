using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsManager : MonoBehaviour
{
    public List<Pin> allPins = new List<Pin>();

    private void Start()
    {
        if(allPins.Count > 0)
        {
            for(int i = 0; i < allPins.Count; i++)
            {
                allPins[i].InitializePinAtPosition();
            }
        }
    }
}
