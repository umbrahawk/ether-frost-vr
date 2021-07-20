using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTarget_CS_EF : MonoBehaviour
{
    // VARIABLES
        // isActive = checks whether the target is currently active - not used for anything at the moment
        // lifetime = how long the target will remain inactive
        // GameObject target = the mesh of the whole target to be moved

    [Header("MAIN STATS")]
    public bool isActive = true;
    public float lifetime = 5.0f;
    public int speed = 1;
    public GameObject target;
    
    [Header("MOVING TARGET")]
    public bool movingTaget = false;
    public float pivotTime = 2.0f;
    public float moveSpeed = 3.0f;
    public bool dirRight = true;

    [Header("MISC")]
    public bool startTarget = false;
    public bool finalRound = false;

    [Header("CONNECTIONS")]
    ParticleSystem sparks;    

    // Where the sound should play from
    public AudioClip hitSoundSFX;

    // For targets which start inactive
    void OnEnable()
    {
        ReactivateTarget();

        if (movingTaget == true)
        {
            StartCoroutine("MoveTarget");
        }
    }

    void Start()
    {
        sparks = GetComponent<ParticleSystem>();

        // Checks if the target is a moving ring or not
        if (movingTaget == true)
        {
            StartCoroutine("MoveTarget");
        }
    }

    void Update()
    {
        // Will move the ring relative to its current location
        if (movingTaget == true)
        {
            if (dirRight)
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            else if (!dirRight)
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        // Checks if the game has 20 seconds left
        if (LevelManager_CS_EF.instance.finalRound == true && !finalRound)
        {
            finalRound = true;
            print("Before the reactivate");
            StartCoroutine("ReactivateTarget");
        }
    }

    IEnumerator ToggleTarget()
    {
        AudioSource.PlayClipAtPoint(hitSoundSFX, new Vector3(0, 0, 0));

        if (!startTarget)
        {
            // Deactives the target
            isActive = false;
        }

        // How many times the loop will run below
        float t = 0;

        // This loop will push the target down into the lying down position
        while (t < 1)
        {
            // Will move the object based on the t variable
            target.transform.localEulerAngles = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 0, -90), t);

            t += Time.deltaTime * speed;

            yield return null;
        }

        // Puts the target in the correct location
        target.transform.localEulerAngles = new Vector3(0, 0, -90);

        if (!startTarget)
        {
            // Variable for how long they will be deactived
            float timer = lifetime;

            // Timer to wait for the targets cooldown
            while (timer > 0)
            {
                timer -= Time.deltaTime;

                yield return null;
            }

            if (LevelManager_CS_EF.instance.finalRound == true)
            {
                // Reactivates the target
                StartCoroutine("ReactivateTarget");
            }
        }

        else if (startTarget)
        {
            LevelManager_CS_EF.instance.BeginGame();
            gameObject.SetActive(false);
        }
    }

    // IEnumerator to return the target back to their regular position
    IEnumerator ReactivateTarget()
    {
        print("Inside Coroutine");
        // How many times the loop will run below
        float t = 0;

        // This loop will bring the target back up to the standing position
        while (t < 1)
        {
            target.transform.localEulerAngles = Vector3.Lerp(new Vector3(0, 0, -90), new Vector3(0, 0, 0), t);

            t += Time.deltaTime * speed;
            yield return null;
        }

        target.transform.localEulerAngles = new Vector3(0, 0, 0);

        // This will reactive the target, allowing for it to be hit again 
        isActive = true;
    }

    // Helps move the rings relative to time elapsed
    IEnumerator MoveTarget()
    {
        if (dirRight)
        {
            yield return new WaitForSeconds(pivotTime);
        }

        else if (!dirRight)
        {
            yield return new WaitForSeconds(pivotTime);
        }

        dirRight = !dirRight;

        StartCoroutine("MoveTarget");
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Projectile_CS_EF>() && isActive == true)
        {
            if (LevelManager_CS_EF.instance.gameActive)
            {
                // this will only work if the isActive is set to true/When the target is up.
                LevelManager_CS_EF.instance.TargetHit();
            }

            sparks.Play();

            StartCoroutine("ToggleTarget");
        }
        else
        {
            print("You hit a non active main Target!");
        }
    }
}
