using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CS_EF : MonoBehaviour
{
    public GameObject swingPoint;

    private void Start()
    {
        StartCoroutine("Rotate");
    }

    IEnumerator Rotate()
    {
        print("Running");
        float t = 10;

        while (t > 0)
        {
            print(t);
            swingPoint.transform.rotation = Quaternion.Euler(9f, 0, 0 * Time.deltaTime) * swingPoint.transform.rotation;
            t--;
            yield return null;
        }
    }
}

