using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunCannon_CS_EF : MonoBehaviour
{
    public float fiveRotateSpeed = 1f;
    public float nineRotateSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (LevelManager_CS_EF.instance.fiveBurstActive)
        {
            transform.Rotate(0, 0, fiveRotateSpeed);
        }

        if (LevelManager_CS_EF.instance.nineBurstActive)
        {
            transform.Rotate(0, 0, nineRotateSpeed);
        }
    }
}
