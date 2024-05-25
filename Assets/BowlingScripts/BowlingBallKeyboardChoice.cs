using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallKeyboardChoice : MonoBehaviour
{
    public List<GameObject> allBowlingBallModels = new List<GameObject>();

    public int currentChoiceIndex = 0;

    private void Start()
    {
        RefreshBowlingBall();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            IterateBowlingBallModel();
        }
    }

    private void IterateBowlingBallModel()
    {
        currentChoiceIndex++; // currentChoiceIndex = currentChoiceIndex + 1;

        if (currentChoiceIndex >= allBowlingBallModels.Count)
            currentChoiceIndex = 0;

        RefreshBowlingBall();
    }

    private void RefreshBowlingBall()
    {
        if (allBowlingBallModels.Count > 0)
        {
            for (int i = 0; i < allBowlingBallModels.Count; i++)
            {
                if (i == currentChoiceIndex)
                    allBowlingBallModels[i].SetActive(true);
                else
                    allBowlingBallModels[i].SetActive(false);
            }
        }
    }
}
