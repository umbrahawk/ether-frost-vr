using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CS_EF : MonoBehaviour
{
    // VARIABLES:
        // spawnPoint = where the projectile gets spawned from
        // projectile = the projectile prefab that gets spawned in
        // canFire = checks whether the player can fire

    public Transform spawnPoint;
    public GameObject projectile;
    public bool canFire = true;

    public static Player_CS_EF instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

        void Update()
    {
        // Checks if the player has input the fire button and can fire
        if (Input.GetButtonDown("Fire1") && canFire)
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
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.fireRate);

        // Flickers whether the player can fire
        canFire = true;
    }

}
