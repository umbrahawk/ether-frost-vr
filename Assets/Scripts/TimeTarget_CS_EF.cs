using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTarget_CS_EF : MonoBehaviour
{
    // VARIABLES
    // isActive = checks whether the target is currently active - not used for anything at the moment
    // lifetime = how long the target will remain inactive
    // GameObject target = the mesh of the whole target to be moved

    public bool isActive = true;
    public float lifetime = 5.0f;
    public GameObject target;

    IEnumerator ToggleTarget()
    {
        // Deactives the target
        isActive = false;

        // Moves the target down on a 90 degree angle
        target.transform.Rotate(0, 0, 90);

        float t = lifetime;

        // Timer to wait for the targets cooldown
        while (t > 0)
        {
            t -= Time.deltaTime;

            yield return null;
        }

        // Reactivates the target
        ActivateTarget();
    }

    public void ActivateTarget()
    {
        // Reactivates the target
        isActive = true;

        // Moves the target back up so it can be fired on again
        target.transform.Rotate(0, 0, -90);
    }


    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Projectile_CS_EF>())
        {
            StartCoroutine("ToggleTarget");
        }
    }
}
