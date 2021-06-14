using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_CS_EF : MonoBehaviour
{
    // VARIABLES
    // isActive = checks whether the target is currently active - not used for anything at the moment
    // balloonSpeed = The speed of the balloon moving upwards

    public bool isActive = true;
    public float balloonSpeed;

    void FixedUpdate()
    {
        //will move the baloon up
        GetComponent<Rigidbody>().AddForce(Vector3.up * balloonSpeed);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Projectile_CS_EF>())
        {
            if (other.gameObject.GetComponent<Projectile_CS_EF>() && isActive == true)
            {
                //When balloon is hit by projectile, will enable gun upgrade script.
                LevelManager_CS_EF.instance.LevelGun();
                print("You hit a Powerup!!");
            }
            /*else
            {
                //if isActive is not true, then it will not add the points.
                print("You hit a non active timer Target!");
            }
            */
        }
    }
}
