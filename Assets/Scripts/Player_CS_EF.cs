using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CS_EF : MonoBehaviour
{
    // VARIABLES:
    // spawnPoint = where the projectile gets spawned from
    // projectile = the projectile prefab that gets spawned in
    // canFire = checks whether the player can fire

    [Header("PROJECTILE SPAWN POINTS")]
    public Transform mainSpawnPoint;
    public Transform extraSpawnPoint1;
    public Transform extraSpawnPoint2;
    public Transform extraSpawnPoint3;
    public Transform extraSpawnPoint4;
    public Transform extraSpawnPoint5;
    public Transform extraSpawnPoint6;
    public Transform extraSpawnPoint7;
    public Transform extraSpawnPoint8;

    [Header("CANNON AUDIO")]
    public AudioClip basicCannonSFX;

    [Header("PLAYER STATS")]
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
        if (Input.GetButton("Fire1") && canFire)
        {
            // Checks if the basic cannon is unlocked
            if (LevelManager_CS_EF.instance.basicCannon == true)
            {
                // Runs the coroutine
                StartCoroutine("FireProjectile");
            }

            if (LevelManager_CS_EF.instance.threeBurstActive == true)
            {
                StartCoroutine("FireThreeBurst");
            }

            if (LevelManager_CS_EF.instance.fiveBurstActive == true)
            {
                StartCoroutine("FireFiveBurst");
            }

            if (LevelManager_CS_EF.instance.nineBurstActive == true)
            {
                StartCoroutine("FireNineBurst");
            }
        }
    }

    // Coroutine to fire the projectile
    IEnumerator FireProjectile()
    {
        // Flickers whether the player can fire
        canFire = false;

        // Plays an audio sound of the cannon
        AudioSource.PlayClipAtPoint(basicCannonSFX, new Vector3(0, 0, 0));

        // Spawns in the projectile
        Instantiate(projectile, mainSpawnPoint.position, mainSpawnPoint.rotation);

        // Waits for the fire rate
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.attackSpeed);

        // Flickers whether the player can fire
        canFire = true;
    }

    IEnumerator FireThreeBurst()
    {
        // Flickers whether the player can fire
        canFire = false;

        // Plays an audio sound of the cannon
        AudioSource.PlayClipAtPoint(basicCannonSFX, new Vector3(0, 0, 0));

        // Spawns in the projectile
        Instantiate(projectile, mainSpawnPoint.position, mainSpawnPoint.rotation);
        Instantiate(projectile, extraSpawnPoint1.position, extraSpawnPoint1.rotation);
        Instantiate(projectile, extraSpawnPoint2.position, extraSpawnPoint2.rotation);

        // Waits for the fire rate
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.attackSpeed);

        // Flickers whether the player can fire
        canFire = true;
    }

    IEnumerator FireFiveBurst()
    {
        // Flickers whether the player can fire
        canFire = false;

        // Spawns in the projectile
        Instantiate(projectile, mainSpawnPoint.position, mainSpawnPoint.rotation);
        Instantiate(projectile, extraSpawnPoint1.position, extraSpawnPoint1.rotation);
        Instantiate(projectile, extraSpawnPoint2.position, extraSpawnPoint2.rotation);
        Instantiate(projectile, extraSpawnPoint3.position, extraSpawnPoint3.rotation);
        Instantiate(projectile, extraSpawnPoint4.position, extraSpawnPoint4.rotation);

        // Waits for the fire rate
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.attackSpeed);

        // Flickers whether the player can fire
        canFire = true;
    }

    IEnumerator FireNineBurst()
    { 
        // Flickers whether the player can fire
        canFire = false;

        // Spawns in the projectile
        Instantiate(projectile, mainSpawnPoint.position, mainSpawnPoint.rotation);
        Instantiate(projectile, extraSpawnPoint1.position, extraSpawnPoint1.rotation);
        Instantiate(projectile, extraSpawnPoint2.position, extraSpawnPoint2.rotation);
        Instantiate(projectile, extraSpawnPoint3.position, extraSpawnPoint3.rotation);
        Instantiate(projectile, extraSpawnPoint4.position, extraSpawnPoint4.rotation);
        Instantiate(projectile, extraSpawnPoint5.position, extraSpawnPoint5.rotation);
        Instantiate(projectile, extraSpawnPoint6.position, extraSpawnPoint6.rotation);
        Instantiate(projectile, extraSpawnPoint7.position, extraSpawnPoint7.rotation);
        Instantiate(projectile, extraSpawnPoint8.position, extraSpawnPoint8.rotation);

        // Waits for the fire rate
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.attackSpeed);

        // Flickers whether the player can fire
        canFire = true;
    }
}
