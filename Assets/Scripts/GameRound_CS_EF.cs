﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRound_CS_EF : MonoBehaviour
{
    public GameObject[] targets;

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

    // Update is called once per frame
    void Update()
    {
        if (LevelManager_CS_EF.instance.roundOne == true && roundOne == true && objectsActivated == false)
        {
            objectsActivated = true;

            ActivateFirstRound();
        }

        if (LevelManager_CS_EF.instance.roundTwo == true && roundTwo == true && objectsActivated == false)
        {
            objectsActivated = true;

            StartCoroutine("ActivateTargets");
        }

        if (LevelManager_CS_EF.instance.roundThree == true && roundThree == true && objectsActivated == false)
        {
            objectsActivated = true;

            StartCoroutine("ActivateTargets");
        }
    }

    IEnumerator ActivateTargets()
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
    
}
