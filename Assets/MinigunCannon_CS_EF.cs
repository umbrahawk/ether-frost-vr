using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunCannon_CS_EF : MonoBehaviour
{
    public int rotateSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        if (LevelManager_CS_EF.instance.nineBurstActive)
        {
            transform.Rotate(0, 0, rotateSpeed);
        }
    }
}
