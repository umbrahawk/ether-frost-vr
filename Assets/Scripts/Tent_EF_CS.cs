using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent_EF_CS : MonoBehaviour
{
    public GameObject[] targets;
    public bool targetsActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        StarterTargets();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager_CS_EF.instance.gameLevel == 2 && !targetsActivated)
        {
            ActivateTargets();
        }
    }

    public void StarterTargets()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(false);
        }
    }

    public void ActivateTargets()
    {
        targetsActivated = true;

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(true);
        }
    }
}
