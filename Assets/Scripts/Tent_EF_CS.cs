using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent_EF_CS : MonoBehaviour
{

    public GameObject starterTargetOne;
    public GameObject starterTargetTwo;
    public GameObject starterTargetThree;
    public GameObject extraTargetOne;
    public GameObject extraTargetTwo;
    public GameObject extraTargetThree;

    // Start is called before the first frame update
    void Start()
    {
        StarterTargets();
        ExtraTargets();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager_CS_EF.instance.targetsHit == 20)
        {
            ActivateExtraTargets();
        }
    }

    public void StarterTargets()
    {
        starterTargetOne.SetActive(true);
        starterTargetTwo.SetActive(true);
        starterTargetThree.SetActive(true);
    }
    public void ExtraTargets()
    {
        extraTargetOne.SetActive(false);
        extraTargetTwo.SetActive(false);
        extraTargetThree.SetActive(false);
    }

    public void ActivateExtraTargets()
    {
        extraTargetOne.SetActive(true);
        extraTargetTwo.SetActive(true);
        extraTargetThree.SetActive(true);
    }
}
