using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTarget_CS_EF : MonoBehaviour
{
    public bool isActive = true;
    public float lifetime = 5.0f;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ToggleTarget");
    }

    IEnumerator ToggleTarget()
    {
        isActive = false;

        float t = lifetime;

        target.transform.Rotate(0, 0, 90);

        while (t > 0)
        {
            t -= Time.deltaTime;

            yield return null;

            //print(lifetime);
        }


        ActivateTarget();
    }

    public void ActivateTarget()
    {
        print("Running the program");

        isActive = true;

        target.transform.Rotate(0, 0, -90);

    }
}
