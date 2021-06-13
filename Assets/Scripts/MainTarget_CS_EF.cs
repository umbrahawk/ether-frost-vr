using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTarget_CS_EF : MonoBehaviour
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

        // How many times the loop will run below
        float t = 10;

        // This loop will push the target down into the lying down position
        while (t > 0)
        {
            target.transform.rotation = Quaternion.Euler(9f, 0, 0 * Time.deltaTime) * target.transform.rotation;

            t--;

            yield return null;
        }

        // Variable for how long they will be deactived
        float timer = lifetime;

        // Timer to wait for the targets cooldown
        while (timer > 0)
        {
            timer -= Time.deltaTime;

            yield return null;
        }

        // Reactivates the target
        StartCoroutine("ReactivateTarget");
    }

    // IEnumerator to return the target back to their regular position
    IEnumerator ReactivateTarget()
    {
        // How many times the loop will run below
        float t = 10;

        // This loop will bring the target back up to the standing position
        while (t > 0)
        {
            target.transform.rotation = Quaternion.Euler(-9f, 0, 0 * Time.deltaTime) * target.transform.rotation;
            t--;
            yield return null;
        }

        // This will reactive the target, allowing for it to be hit again 
        isActive = true;
    }


    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Projectile_CS_EF>() && isActive == true)
        {
            //this will only work if the isActive is set to true/When the target is up.
            LevelManager_CS_EF.instance.TargetHit();
            StartCoroutine("ToggleTarget");
        }
        else
        {
            print("You hit a non active main Target!");
        }
    }
}
