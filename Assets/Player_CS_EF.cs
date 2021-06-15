using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CS_EF : MonoBehaviour
{
    // VARIABLES:
        // spawnPoint = where the projectile gets spawned from
        // projectile = the projectile prefab that gets spawned in
        // canFire = checks whether the player can fire
        // fireRate = how fast the player does fire

    public Transform spawnPoint;
    public GameObject projectile;
    public bool canFire = true;
    public float fireRate = 0.5f;

    
    void Update()
    {
        // Checks if the player has input the fire button and can fire
        if (Input.GetKeyDown("1") && canFire)
        {
            // Runs the coroutine
            StartCoroutine("FireProjectile");
        }
    }

    // Coroutine to fire the projectile
    IEnumerator FireProjectile()
    {
        // Flickers whether the player can fire
        canFire = false;

        // Spawns in the projectile
        Instantiate(projectile, spawnPoint);

        // Waits for the fire rate
        yield return new WaitForSeconds(fireRate);

        // Flickers whether the player can fire
        canFire = true;
    }

}
