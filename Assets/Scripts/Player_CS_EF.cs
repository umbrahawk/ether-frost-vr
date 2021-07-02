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
    public Transform rightMainSpawnPoint;
    public Transform rightExtraSpawnPoint1;
    public Transform rightExtraSpawnPoint2;
    public Transform rightExtraSpawnPoint3;
    public Transform rightExtraSpawnPoint4;
    public Transform rightExtraSpawnPoint5;
    public Transform rightExtraSpawnPoint6;
    public Transform rightExtraSpawnPoint7;
    public Transform rightExtraSpawnPoint8;

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
        Instantiate(projectile, rightMainSpawnPoint.position, rightMainSpawnPoint.rotation);

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
        Instantiate(projectile, rightMainSpawnPoint.position, rightMainSpawnPoint.rotation);
        Instantiate(projectile, rightExtraSpawnPoint1.position, rightExtraSpawnPoint1.rotation);
        Instantiate(projectile, rightExtraSpawnPoint2.position, rightExtraSpawnPoint2.rotation);

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
        Instantiate(projectile, rightMainSpawnPoint.position, rightMainSpawnPoint.rotation);
        Instantiate(projectile, rightExtraSpawnPoint1.position, rightExtraSpawnPoint1.rotation);
        Instantiate(projectile, rightExtraSpawnPoint2.position, rightExtraSpawnPoint2.rotation);
        Instantiate(projectile, rightExtraSpawnPoint3.position, rightExtraSpawnPoint3.rotation);
        Instantiate(projectile, rightExtraSpawnPoint4.position, rightExtraSpawnPoint4.rotation);

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
        Instantiate(projectile, rightMainSpawnPoint.position, rightMainSpawnPoint.rotation);
        Instantiate(projectile, rightExtraSpawnPoint1.position, rightExtraSpawnPoint1.rotation);
        Instantiate(projectile, rightExtraSpawnPoint2.position, rightExtraSpawnPoint2.rotation);
        Instantiate(projectile, rightExtraSpawnPoint3.position, rightExtraSpawnPoint3.rotation);
        Instantiate(projectile, rightExtraSpawnPoint4.position, rightExtraSpawnPoint4.rotation);
        Instantiate(projectile, rightExtraSpawnPoint5.position, rightExtraSpawnPoint5.rotation);
        Instantiate(projectile, rightExtraSpawnPoint6.position, rightExtraSpawnPoint6.rotation);
        Instantiate(projectile, rightExtraSpawnPoint7.position, rightExtraSpawnPoint7.rotation);
        Instantiate(projectile, rightExtraSpawnPoint8.position, rightExtraSpawnPoint8.rotation);

        // Waits for the fire rate
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.attackSpeed);

        // Flickers whether the player can fire
        canFire = true;
    }
}
