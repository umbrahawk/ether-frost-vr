using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTarget_CS_EF : MonoBehaviour
{
    // VARIABLES
    // isActive = checks whether the target is currently active - not used for anything at the moment
    // lifetime = how long the target will remain inactive
    // GameObject target = the mesh of the whole target to be moved

    [Header("MAIN STATS")]
    public bool isActive = true;
    public bool canBeHit = true;
    public float lifetime;
    public int speed = 1;
    public GameObject target;
    public GameObject player;

    [Header("TARGET TYPES")]
    public bool regularTarget = false;
    public bool duckTarget = false;
    public bool continuousTarget = false;
    public bool startTarget = false;
    public bool fallingTarget = false;

    [Header("MOVING TARGET")]
    public bool movingTaget = false;
    public float pivotTime = 2.0f;
    public float moveSpeed = 3.0f;
    public bool dirRight = true;

    [Header("FALLING TARGET")]
    public float fallSpeed;

    [Header("MISC")]
    public bool finalRound = false;

    [Header("CONNECTIONS")]
    ParticleSystem sparks;

    // Where the sound should play from
    [Header("NORMAL TARGET SOUNDS")]
    public AudioClip hitSound1VFX;
    public AudioClip hitSound2VFX;
    public AudioClip hitSound3VFX;
    public AudioClip hitSound4VFX;
    public AudioClip hitSound5VFX;
    public AudioClip hitSound6VFX;

    [Header("DUCK TARGET SOUNDS")]
    public AudioClip duckSound1VFX;
    public AudioClip duckSound2VFX;
    public AudioClip duckSound3VFX;
    public AudioClip duckSound4VFX;
    public AudioClip duckSound5VFX;

    [Header("TEXT ANIMATION")]
    public Animator textAnimation;
    public Text popppingText1;

    [Header("OUTLINE")]
    Outline toggle;

    // For targets which start inactive
    void OnEnable()
    {
        toggle = GetComponent<Outline>();
        toggle.enabled = true;
        if (movingTaget == true)
        {
            StartCoroutine("MoveTarget");
        }

        if (continuousTarget)
        {
            lifetime = 4;
        }

        else if (!continuousTarget)
        {
            lifetime = 10;
        }

        if (!fallingTarget)
        {
            SpawnTarget();
        }

        else if (fallingTarget == true)
        {
            StartCoroutine("RotateTarget");
        }

    }

    void Start()
    {
        sparks = GetComponent<ParticleSystem>();
        toggle = GetComponent<Outline>();
        toggle.enabled = true;
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
            SpawnTarget();
        }

        if (LevelManager_CS_EF.instance.gameEnded == true && toggle != null)
        {
            toggle.enabled = false;
        }

    }


    IEnumerator ToggleTarget()
    {
        if (regularTarget)
        {
            PlayRegularSound();
        }

        else if (duckTarget)
        {
            PlayDuckSound();
        }

        else if (fallingTarget)
        {
            PlayRegularSound();
            Destroy(gameObject, .1f);
        }

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

        if (continuousTarget)
        {
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

        else if (!startTarget)
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

        else if (startTarget && LevelManager_CS_EF.instance.gameActive == false)
        {
            LevelManager_CS_EF.instance.StartCoroutine("BeginGame");
            gameObject.SetActive(false);
        }
    }

    // IEnumerator to return the target back to their regular position
    IEnumerator ReactivateTarget()
    {
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

    IEnumerator RotateTarget()
    {
        GameObject obj = GameObject.Find("PlayerGamePoint_EF");

        Quaternion rot = Quaternion.LookRotation(obj.transform.position - transform.position);

        rot.x = 0;
        rot.z = 0;
        transform.rotation = rot;

        yield return null;
    }

    // Helps move the rings relative to time elapsed
    IEnumerator MoveTarget()
    {
        if (dirRight)
        {
            yield return new WaitForSeconds(pivotTime);
            dirRight = false;
        }

        else if (!dirRight)
        {
            yield return new WaitForSeconds(pivotTime);
            dirRight = true;
        }

        StartCoroutine("MoveTarget");
    }

    public void PlayRegularSound()
    {
        int playSound = Random.Range(0, 6);

        switch (playSound)
        {
            case 0:
                AudioSource.PlayClipAtPoint(hitSound1VFX, player.transform.position, 1f);
                break;
                
            case 1:
                AudioSource.PlayClipAtPoint(hitSound2VFX, player.transform.position, 1f);
                break;

            case 2:
                AudioSource.PlayClipAtPoint(hitSound3VFX, player.transform.position, 1f);
                break;

            case 3:
                AudioSource.PlayClipAtPoint(hitSound4VFX, player.transform.position, 1f);
                break;

            case 4:
                AudioSource.PlayClipAtPoint(hitSound5VFX, player.transform.position, 1f);
                break;

            case 5:
                AudioSource.PlayClipAtPoint(hitSound6VFX, player.transform.position, 1f);
                break;

            default:
                break;
        }
    }

    public void PlayDuckSound()
    {
        int playSound = Random.Range(0, 5);

        switch (playSound)
        {
            case 0:
                AudioSource.PlayClipAtPoint(duckSound1VFX, player.transform.position, 1f);
                break;

            case 1:
                AudioSource.PlayClipAtPoint(duckSound2VFX, player.transform.position, 1f);
                break;

            case 2:
                AudioSource.PlayClipAtPoint(duckSound3VFX, player.transform.position, 1f);
                break;

            case 3:
                AudioSource.PlayClipAtPoint(duckSound4VFX, player.transform.position, 1f);
                break;

            case 4:
                AudioSource.PlayClipAtPoint(duckSound5VFX, player.transform.position, 1f);
                break;

            default:
                break;
        }
    }
    public void SpawnTarget()
    {
        // Starts in the down position
        target.transform.localEulerAngles = new Vector3(0, 0, -90);

        StartCoroutine("ReactivateTarget");
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

            int toPopText = Random.Range(0, 2);

            if (textAnimation != null && toPopText == 1)
            {
                int randAnim = Random.Range(0, 2);
                //print(randAnim);

                int randColor1 = Random.Range(0, 8);
                print(randColor1);
                if (randColor1 == 1)
                {
                    popppingText1.color = new Color32(251, 237, 72, 255);
                }
                else if (randColor1 == 2)
                {
                    popppingText1.color = new Color32(44, 50, 223, 255);
                }
                else if (randColor1 == 3)
                {
                    popppingText1.color = new Color32(227, 50, 52, 255);
                }
                else if (randColor1 == 4)
                {
                    popppingText1.color = new Color32(138, 48, 219, 255);
                }
                else if (randColor1 == 5)
                {
                    popppingText1.color = new Color32(93, 247, 93, 255);
                }
                else if (randColor1 == 6)
                {
                    popppingText1.color = new Color32(232, 83, 217, 255);
                }
                else if (randColor1 == 7)
                {
                    popppingText1.color = new Color32(227, 133, 32, 255);
                }


                //Apply Random text for randText1

                int randText1 = Random.Range(0, 6);
                //print(randText1);

                if (randText1 == 1)
                {
                    popppingText1.text = "DANG";
                }
                else if (randText1 == 2)
                {
                    popppingText1.text = "WOW";
                }
                else if (randText1 == 3)
                {
                    popppingText1.text = "NICE";
                }
                else if (randText1 == 4)
                {
                    popppingText1.text = "AWESOME";
                }
                else if (randText1 == 5)
                {
                    popppingText1.text = "AMAZING";
                }


                if (randAnim == 1)
                {
                    textAnimation.Play("PoppingText1");
                }
                else
                {
                    textAnimation.Play("PoppingText2");
                }

            }

            StartCoroutine("ToggleTarget");
        }


        if (fallingTarget)
        {
            if (other.gameObject.GetComponent<CircusFloor_EF_CS>() || other.gameObject.GetComponent<CartWayPoint_CS_EF>())
            {
                Destroy(gameObject);
            }
        }

    }
}
