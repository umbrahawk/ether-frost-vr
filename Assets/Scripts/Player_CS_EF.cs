using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CS_EF : MonoBehaviour
{
    // VARIABLES:
    // spawnPoint = where the projectile gets spawned from
    // projectile = the projectile prefab that gets spawned in
    // canFire = checks whether the player can fire

    [Header("PROJECTILE SPAWN POINTS // Right")]
    public Transform rightMainSpawnPoint;
    public Transform rightExtraSpawnPoint1;
    public Transform rightExtraSpawnPoint2;
    public Transform rightExtraSpawnPoint3;
    public Transform rightExtraSpawnPoint4;
    public Transform rightExtraSpawnPoint5;
    public Transform rightExtraSpawnPoint6;
    public Transform rightExtraSpawnPoint7;
    public Transform rightExtraSpawnPoint8;

    [Header("PROJECTILE SPAWN POINTS // Left")]
    public Transform leftMainSpawnPoint;
    public Transform leftExtraSpawnPoint1;
    public Transform leftExtraSpawnPoint2;
    public Transform leftExtraSpawnPoint3;
    public Transform leftExtraSpawnPoint4;
    public Transform leftExtraSpawnPoint5;
    public Transform leftExtraSpawnPoint6;
    public Transform leftExtraSpawnPoint7;
    public Transform leftExtraSpawnPoint8;

    [Header("PROJECTILE SPAWN POINTS // 5 Burst Right")]
    public Transform rightFiveBurst1;
    public Transform rightFiveBurst2;
    public Transform rightFiveBurst3;
    public Transform rightFiveBurst4;

    [Header("PROJECTILE SPAWN POINTS // 5 Burst Left")]
    public Transform leftFiveBurst1;
    public Transform leftFiveBurst2;
    public Transform leftFiveBurst3;
    public Transform leftFiveBurst4;

    [Header("CANNON AUDIO")]
    public AudioClip basicCannonSFX;

    [Header("PLAYER STATS")]
    public GameObject projectile;
    public bool rightCanFire = true;
    public bool leftCanFire = true;
    public bool canBothFire = true;

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
        if (Input.GetButton("Fire1") && rightCanFire && canBothFire == true)
        {
            // Checks if the basic cannon is unlocked
            if (LevelManager_CS_EF.instance.basicCannon == true )
            {
                // Runs the coroutine
                StartCoroutine("FireRightProjectile");
            }

            if (LevelManager_CS_EF.instance.threeBurstActive == true)
            {
                StartCoroutine("FireRightThreeBurst");
            }

            if (LevelManager_CS_EF.instance.fiveBurstActive == true)
            {
                StartCoroutine("FireRightFiveBurst");
            }

            if (LevelManager_CS_EF.instance.nineBurstActive == true)
            {
                StartCoroutine("FireRightNineBurst");
            }
        }
        /*
        // Checks if the player has input the fire button and can fire
        if (Input.GetButton("Fire1") && leftCanFire && canBothFire == true)
        {
            // Checks if the basic cannon is unlocked
            if (LevelManager_CS_EF.instance.basicCannon == true)
            {
                // Runs the coroutine
                StartCoroutine("FireLeftProjectile");
            }

            if (LevelManager_CS_EF.instance.threeBurstActive == true)
            {
                StartCoroutine("FireLeftThreeBurst");
            }

            if (LevelManager_CS_EF.instance.fiveBurstActive == true)
            {
                StartCoroutine("FireLeftFiveBurst");
            }

            if (LevelManager_CS_EF.instance.nineBurstActive == true)
            {
                StartCoroutine("FireLeftNineBurst");
            }
        }
        */
    }

    // Coroutine to fire the projectile
    IEnumerator FireRightProjectile()
    {
        // Flickers whether the player can fire
        rightCanFire = false;

        // Plays an audio sound of the cannon
        AudioSource.PlayClipAtPoint(basicCannonSFX, new Vector3(0, 0, 0));

        // Spawns in the projectile
        Instantiate(projectile, rightMainSpawnPoint.position, rightMainSpawnPoint.rotation);

        // Waits for the fire rate
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.attackSpeed);

        // Flickers whether the player can fire
        rightCanFire = true;
    }
    
    // Coroutine to fire the projectile
    IEnumerator FireLeftProjectile()
    {
        // Flickers whether the player can fire
        leftCanFire = false;

        // Plays an audio sound of the cannon
        AudioSource.PlayClipAtPoint(basicCannonSFX, new Vector3(0, 0, 0));

        // Spawns in the projectile
        Instantiate(projectile, leftMainSpawnPoint.position, leftMainSpawnPoint.rotation);

        // Waits for the fire rate
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.attackSpeed);

        // Flickers whether the player can fire
        leftCanFire = true;
    }

    IEnumerator FireRightThreeBurst()
    {
        // Flickers whether the player can fire
        rightCanFire = false;

        // Plays an audio sound of the cannon
        AudioSource.PlayClipAtPoint(basicCannonSFX, new Vector3(0, 0, 0));

        // Spawns in the projectile
        Instantiate(projectile, rightMainSpawnPoint.position, rightMainSpawnPoint.rotation);
        Instantiate(projectile, rightExtraSpawnPoint1.position, rightExtraSpawnPoint1.rotation);
        Instantiate(projectile, rightExtraSpawnPoint2.position, rightExtraSpawnPoint2.rotation);

        // Waits for the fire rate
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.attackSpeed);

        // Flickers whether the player can fire
        rightCanFire = true;
    }
    IEnumerator FireLeftThreeBurst()
    {
        // Flickers whether the player can fire
        leftCanFire = false;

        // Plays an audio sound of the cannon
        AudioSource.PlayClipAtPoint(basicCannonSFX, new Vector3(0, 0, 0));

        // Spawns in the projectile
        Instantiate(projectile, leftMainSpawnPoint.position, leftMainSpawnPoint.rotation);
        Instantiate(projectile, leftExtraSpawnPoint1.position, leftExtraSpawnPoint1.rotation);
        Instantiate(projectile, leftExtraSpawnPoint2.position, leftExtraSpawnPoint2.rotation);

        // Waits for the fire rate
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.attackSpeed);

        // Flickers whether the player can fire
        leftCanFire = true;
    }

    IEnumerator FireRightFiveBurst()
    {
        // Flickers whether the player can fire
        rightCanFire = false;

        // Plays an audio sound of the cannon
        AudioSource.PlayClipAtPoint(basicCannonSFX, new Vector3(0, 0, 0));

        // Spawns in the projectile
        Instantiate(projectile, rightMainSpawnPoint.position, rightMainSpawnPoint.rotation);
        Instantiate(projectile, rightFiveBurst1.position, rightFiveBurst1.rotation);
        Instantiate(projectile, rightFiveBurst2.position, rightFiveBurst2.rotation);
        Instantiate(projectile, rightFiveBurst3.position, rightFiveBurst3.rotation);
        Instantiate(projectile, rightFiveBurst4.position, rightFiveBurst4.rotation);

        // Waits for the fire rate
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.attackSpeed);

        // Flickers whether the player can fire
        rightCanFire = true;
    }
    IEnumerator FireLeftFiveBurst()
    {
        // Flickers whether the player can fire
        leftCanFire = false;

        // Plays an audio sound of the cannon
        AudioSource.PlayClipAtPoint(basicCannonSFX, new Vector3(0, 0, 0));

        // Spawns in the projectile
        Instantiate(projectile, leftMainSpawnPoint.position, leftMainSpawnPoint.rotation);
        Instantiate(projectile, leftFiveBurst1.position, leftFiveBurst1.rotation);
        Instantiate(projectile, leftFiveBurst2.position, leftFiveBurst2.rotation);
        Instantiate(projectile, leftFiveBurst3.position, leftFiveBurst3.rotation);
        Instantiate(projectile, leftFiveBurst4.position, leftFiveBurst4.rotation);

        // Waits for the fire rate
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.attackSpeed);

        // Flickers whether the player can fire
        leftCanFire = true;
    }

    IEnumerator FireRightNineBurst()
    {
        // Flickers whether the player can fire
        rightCanFire = false;

        // Plays an audio sound of the cannon
        AudioSource.PlayClipAtPoint(basicCannonSFX, new Vector3(0, 0, 0));

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
        rightCanFire = true;
    }
    IEnumerator FireLeftNineBurst()
    {
        // Flickers whether the player can fire
        leftCanFire = false;

        // Plays an audio sound of the cannon
        AudioSource.PlayClipAtPoint(basicCannonSFX, new Vector3(0, 0, 0));

        // Spawns in the projectile
        Instantiate(projectile, leftMainSpawnPoint.position, leftMainSpawnPoint.rotation);
        Instantiate(projectile, leftExtraSpawnPoint1.position, leftExtraSpawnPoint1.rotation);
        Instantiate(projectile, leftExtraSpawnPoint2.position, leftExtraSpawnPoint2.rotation);
        Instantiate(projectile, leftExtraSpawnPoint3.position, leftExtraSpawnPoint3.rotation);
        Instantiate(projectile, leftExtraSpawnPoint4.position, leftExtraSpawnPoint4.rotation);
        Instantiate(projectile, leftExtraSpawnPoint5.position, leftExtraSpawnPoint5.rotation);
        Instantiate(projectile, leftExtraSpawnPoint6.position, leftExtraSpawnPoint6.rotation);
        Instantiate(projectile, leftExtraSpawnPoint7.position, leftExtraSpawnPoint7.rotation);
        Instantiate(projectile, leftExtraSpawnPoint8.position, leftExtraSpawnPoint8.rotation);

        // Waits for the fire rate
        yield return new WaitForSeconds(LevelManager_CS_EF.instance.attackSpeed);

        // Flickers whether the player can fire
        leftCanFire = true;
    }
}
