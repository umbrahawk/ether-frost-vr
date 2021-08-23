﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRound_CS_EF : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject[] subRoundTargets1;
    public GameObject[] subRoundTargets2;
    public GameObject[] subRoundTargets3;
    public GameObject[] subRoundTargets4;
    public GameObject[] subRoundTargets5;
    public bool roundOne = false;
    public bool roundTwo = false;
    public bool roundThree = false;

    public bool objectsActivated = false;

    private void Start()
    {
        DeactivateAllTargets();
    }


    void Update()
    {
        // Checks which round it is, whether if it the round one targets, and whether the targets are activated
        if (LevelManager_CS_EF.instance.roundOne == true && roundOne == true && objectsActivated == false)
        {
            objectsActivated = true;

            ActivateFirstSubRoundTargets();
        }

        // Checks which round it is, whether if it the round two targets, and whether the targets are activated
        if (LevelManager_CS_EF.instance.roundTwo == true && roundTwo == true && objectsActivated == false)
        {
            objectsActivated = true;

            StartCoroutine("ActivateTargetDelay");


        }

        // Checks which round it is, whether if it the round three targets, and whether the targets are activated
        if (LevelManager_CS_EF.instance.roundThree == true && roundThree == true && objectsActivated == false)
        {
            objectsActivated = true;

            StartCoroutine("ActivateTargetDelay");

        }
    }

    IEnumerator ActivateTargetDelay()
    {
        yield return new WaitForSeconds(2);

        if (roundTwo)
        {
            ActivateSecondSubRoundTargets();
        }

        else if (roundThree)
        {
            ActivateThirdSubRoundTargets();
        }
    }

    // Used to actvate the targets in the first round of the experience
    public void ActivateFirstSubRoundTargets()
    {
        print("Round1");
        if (LevelManager_CS_EF.instance.subRound == 1)
        {
            for (int i = 0; i < subRoundTargets1.Length; i++)
            {
                subRoundTargets1[i].SetActive(true);
            }
        }

        else if (LevelManager_CS_EF.instance.subRound == 2)
        {
            for (int i = 0; i < subRoundTargets2.Length; i++)
            {
                subRoundTargets2[i].SetActive(true);
            }
        }

        else if (LevelManager_CS_EF.instance.subRound == 3)
        {
            for (int i = 0; i < subRoundTargets3.Length; i++)
            {
                subRoundTargets3[i].SetActive(true);
            }
        }

        else if (LevelManager_CS_EF.instance.subRound == 4)
        {
            for (int i = 0; i < subRoundTargets4.Length; i++)
            {
                subRoundTargets4[i].SetActive(true);
            }
        }

        if (LevelManager_CS_EF.instance.subRound < 4)
        {
            StartCoroutine("WaitForNextSubRound");
        }
    }


    public void ActivateSecondSubRoundTargets()
    {
        print("Round2");
        if (LevelManager_CS_EF.instance.subRound == 1)
        {
            for (int i = 0; i < subRoundTargets1.Length; i++)
            {
                subRoundTargets1[i].SetActive(true);
            }
        }

        else if (LevelManager_CS_EF.instance.subRound == 2)
        {
            for (int i = 0; i < subRoundTargets2.Length; i++)
            {
                subRoundTargets2[i].SetActive(true);
            }
        }

        else if (LevelManager_CS_EF.instance.subRound == 3)
        {
            for (int i = 0; i < subRoundTargets3.Length; i++)
            {
                subRoundTargets3[i].SetActive(true);
            }
        }

        else if (LevelManager_CS_EF.instance.subRound == 4)
        {
            for (int i = 0; i < subRoundTargets4.Length; i++)
            {
                subRoundTargets4[i].SetActive(true);
            }
        }

        if (LevelManager_CS_EF.instance.subRound < 4)
        {
            StartCoroutine("WaitForNextSubRound");
        }
    }

    public void ActivateThirdSubRoundTargets()
    {
        print("Round3");
        if (LevelManager_CS_EF.instance.subRound == 1)
        {
            for (int i = 0; i < subRoundTargets1.Length; i++)
            {
                subRoundTargets1[i].SetActive(true);
            }
        }

        if (LevelManager_CS_EF.instance.subRound == 2)
        {
            for (int i = 0; i < subRoundTargets2.Length; i++)
            {
                subRoundTargets2[i].SetActive(true);
            }
        }

        if (LevelManager_CS_EF.instance.subRound == 3)
        {
            for (int i = 0; i < subRoundTargets3.Length; i++)
            {
                subRoundTargets3[i].SetActive(true);
            }
        }

        if (LevelManager_CS_EF.instance.subRound == 4)
        {
            for (int i = 0; i < subRoundTargets4.Length; i++)
            {
                subRoundTargets4[i].SetActive(true);
            }
        }

        if (LevelManager_CS_EF.instance.subRound == 5)
        {
            for (int i = 0; i < subRoundTargets5.Length; i++)
            {
                subRoundTargets5[i].SetActive(true);
            }
        }

        if (LevelManager_CS_EF.instance.subRound < 5)
        {
            StartCoroutine("WaitForNextSubRound");
        }
    }

    IEnumerator WaitForNextSubRound()
    {
        yield return new WaitForSeconds(5f);

        LevelManager_CS_EF.instance.subRound++;
        print(LevelManager_CS_EF.instance.subRound);

        if (roundOne)
        {
            ActivateFirstSubRoundTargets();
        }

        else if (roundTwo)
        {
            ActivateFirstSubRoundTargets();
        }

        else if (roundThree)
        {
            ActivateFirstSubRoundTargets();
        }
    }

    public void DeactivateAllTargets()
    {
        for (int i = 0; i < subRoundTargets1.Length; i++)
        {
            subRoundTargets1[i].SetActive(false);
        }

        for (int i = 0; i < subRoundTargets2.Length; i++)
        {
            subRoundTargets2[i].SetActive(false);
        }

        for (int i = 0; i < subRoundTargets3.Length; i++)
        {
            subRoundTargets3[i].SetActive(false);
        }

        for (int i = 0; i < subRoundTargets4.Length; i++)
        {
            subRoundTargets4[i].SetActive(false);
        }

        for (int i = 0; i < subRoundTargets5.Length; i++)
        {
            subRoundTargets5[i].SetActive(false);
        }
    }
}
