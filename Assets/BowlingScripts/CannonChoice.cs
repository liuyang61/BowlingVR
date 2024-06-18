using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonChoice : MonoBehaviour
{
    public int cannonChoice = 0;

    public List<GameObject> cannons = new List<GameObject>();

    public List<Transform> launchPlaceholders = new List<Transform>();

    private void Start()
    {
        if(cannons.Count > 0)
        {
            for(int i = 0; i < cannons.Count; i++)
            {
                if (i == cannonChoice)
                    cannons[i].SetActive(true);
                else
                    cannons[i].SetActive(false);
            }
        }
    }
}
