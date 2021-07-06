using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGallery_CS_EF : MonoBehaviour
{
    public GameObject[] setOneTargets;
    public GameObject[] setTwoTargets;
    public GameObject[] setThreeTargets;

    public bool setOneTargetsActivated = false;
    public bool setTwoTargetsActivated = false;
    public bool setThreeTargetsActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        StarterTargets();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager_CS_EF.instance.gameLevel == 1 && !setOneTargetsActivated)
        {
            ActivateSetOneTargets();
        }

        if (LevelManager_CS_EF.instance.gameLevel == 3 && !setTwoTargetsActivated)
        {
            ActivateSetTwoTargets();
        }

        if (LevelManager_CS_EF.instance.gameLevel == 4 && !setThreeTargetsActivated)
        {
            ActivateSetThreeTargets();
        }
    }

    public void StarterTargets()
    {
        for (int i = 0; i < setOneTargets.Length; i++)
        {
            setOneTargets[i].SetActive(false);
        }

        for (int i = 0; i < setTwoTargets.Length; i++)
        {
            setTwoTargets[i].SetActive(false);
        }

        for (int i = 0; i < setThreeTargets.Length; i++)
        {
            setThreeTargets[i].SetActive(false);
        }
    }

    public void ActivateSetOneTargets()
    {
        setOneTargetsActivated = true;

        for (int i = 0; i < setOneTargets.Length; i++)
        {
            setOneTargets[i].SetActive(true);
        }
    }
    public void ActivateSetTwoTargets()
    {
        setOneTargetsActivated = true;

        for (int i = 0; i < setTwoTargets.Length; i++)
        {
            setTwoTargets[i].SetActive(true);
        }
    }
    public void ActivateSetThreeTargets()
    {
        setOneTargetsActivated = true;

        for (int i = 0; i < setThreeTargets.Length; i++)
        {
            setThreeTargets[i].SetActive(true);
        }
    }

}
