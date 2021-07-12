using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRound_CS_EF : MonoBehaviour
{
    public GameObject[] targets;

    public bool roundOne = false;
    public bool roundTwo = false;
    public bool roundThree = false;
    public bool roundFour = false;
    public bool finalRound = false;

    public bool objectsActivated = false;

    // Update is called once per frame
    void Update()
    {
        if (LevelManager_CS_EF.instance.roundOne == true && roundOne == true && objectsActivated == false)
        {
            objectsActivated = true;

            ActivateTargets();
        }

        if (LevelManager_CS_EF.instance.roundTwo == true && roundTwo == true && objectsActivated == false)
        {
            objectsActivated = true;

            ActivateTargets();
        }
    }

    public void ActivateTargets()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(true);
        }
    }
}
