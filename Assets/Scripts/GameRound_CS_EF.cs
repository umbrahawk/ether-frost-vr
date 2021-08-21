using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRound_CS_EF : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject[] subRoundTargets;
    public GameObject[] subRoundTargets1;
    public GameObject[] subRoundTargets2;
    public bool roundOne = false;
    public bool roundTwo = false;
    public bool roundThree = false;
    public bool finalRound = false;

    public bool objectsActivated = false;

    private void Start()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(false);
        }
    }


    void Update()
    {
        // Checks which round it is, whether if it the round one targets, and whether the targets are activated
        if (LevelManager_CS_EF.instance.roundOne == true && roundOne == true && objectsActivated == false)
        {
            objectsActivated = true;

            ActivateFirstRound();
        }

        // Checks which round it is, whether if it the round two targets, and whether the targets are activated
        if (LevelManager_CS_EF.instance.roundTwo == true && roundTwo == true && objectsActivated == false)
        {
            objectsActivated = true;

            StartCoroutine("ActivateTarget");
        }

        // Checks which round it is, whether if it the round three targets, and whether the targets are activated
        if (LevelManager_CS_EF.instance.roundThree == true && roundThree == true && objectsActivated == false)
        {
            objectsActivated = true;

            StartCoroutine("ActivateTarget");
        }
    }

    IEnumerator ActivateTarget()
    {
        yield return new WaitForSeconds(2);

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(true);
        }
    }

    public void ActivateFirstRound()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(true);
        }
    }

    /*
    public void ActivateSubRoundTargets()
    {
        for (int i = 0; i < subRoundTargets.Length; i++)
        {
            subRoundTargets[i].SetActive(true);
        }

        StartCoroutine("WaitForNextRound");
    }

    public void ActivateSubRoundTargets1()
    {
        for (int i = 0; i < subRoundTargets1.Length; i++)
        {
            subRoundTargets1[i].SetActive(true);
        }

        StartCoroutine("WaitForNextRound1");
    }
    public void ActivateSubRoundTargets2()
    {
        for (int i = 0; i < subRoundTargets2.Length; i++)
        {
            subRoundTargets2[i].SetActive(true);
        }

        StartCoroutine("WaitForNextRound1");
    }

    IEnumerator WaitForNextRound()
    {
        yield return new WaitForSeconds(4f);

        ActivateSubRoundTargets1();
    }

    IEnumerator WaitForNextRound1()
    {
        yield return new WaitForSeconds(3f);

        ActivateSubRoundTargets2();
    }
    */
}
