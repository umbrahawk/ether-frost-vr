using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTable_CS_EF : MonoBehaviour
{
    /*
    public GameObject starterTargetOne;
    public GameObject starterTargetTwo;
    public GameObject extraTargetOne;
    public GameObject extraTargetTwo;
    */

    public float rotateSpeed = 0.5f;

    void Start()
    {
        /*
        StarterTargets();
        ExtraTargets();
        */
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }

    /*
    public void StarterTargets()
    {
        starterTargetOne.SetActive(true);
        starterTargetTwo.SetActive(true);
    }
    public void ExtraTargets()
    {
        extraTargetOne.SetActive(false);
        extraTargetTwo.SetActive(false);
    }

    public void ActivateExtraTargets()
    {
        extraTargetOne.SetActive(true);
        extraTargetTwo.SetActive(true);
    }
    */
}
