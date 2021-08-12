using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager_CS_EF : MonoBehaviour
{

    [Header("GAME STATS")]
    public GameObject player;
    public bool gameActive = false;
    public int gameLevel = 0;
    public bool roundOne = false;
    public bool roundTwo = false;
    public bool roundThree = false;
    public bool finalRound = false;
    public int roundTwoTransition = 95;
    public int roundThreeTransition = 69;
    public int finalRoundTransition = 37;

    [Header("TIMER STATS")]
    public float startingTime = 120;
    public float currentTime;
    public float increaseAmount = 5;
    public Text TimerText;

    [Header("TARGET STATS")]
    public int targetsHit = 0;
    public Text targetText;

    [Header("PLAYER STATS")]
    public bool rapidFireActive = false;
    public float attackSpeed;
    public float fireRate = 0.25f;

    [Header("CANNON STATS")]
    public bool basicCannon = true;
    public bool threeBurstActive = false;
    public bool fiveBurstActive = false;
    public bool nineBurstActive = false;

    [Header("CANNON MESHES")]
    public GameObject mainCannonPrimary;
    public GameObject threeBurstCannonPrimary;
    public GameObject fiveBurstCannonPrimary;
    public GameObject nineBurstCannonPrimary;
    public GameObject mainCannonSecondary;
    public GameObject threeBurstCannonSecondary;
    public GameObject fiveBurstCannonSecondary;
    public GameObject nineBurstCannonSecondary;

    [Header("GUN STATS")]
    public Animator textAnimator;
    public Animator lightAnimator;

    [Header("SOUND EFFECTS")]
    public AudioClip gameBackgroundMusic;
    public AudioClip cannonUpgradeSFX;
    public AudioClip finalCrowdCheerSFX;
    public bool playFinalCheer = true;

    [Header("CROWD CHEERING SFX")]
    public AudioClip crowdCheering1SFX;
    public AudioClip crowdCheering2SFX;
    public AudioClip crowdCheering3SFX;
    public AudioClip crowdCheering4SFX;
    public AudioClip crowdCheering5SFX;
    public AudioClip crowdCheering6SFX;
    public AudioClip crowdCheering7SFX;
    public AudioClip crowdCheering8SFX;
    public AudioClip crowdCheering9SFX;

    [Header("VISUAL EFFECTS")]
    public GameObject upgradeEffectPrimary;
    public GameObject upgradeEffectSecondary;
    public GameObject secondEffectPrimary;
    public GameObject secondEffectSecondary;

    [Header("MISC")]
    public Rigidbody[] gunBarrel;
    public Transform playerGamePoint;


    public static LevelManager_CS_EF instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        ResetCannon();



        // This will need to be fixed 
        //gameOverText.gameObject.SetActive(false);

        currentTime = startingTime;

        TimerText.text = "02  :  00";

        //targetText.text = "Targets hit: " + targetsHit;

        upgradeEffectPrimary.SetActive(false);
        upgradeEffectSecondary.SetActive(false);
        secondEffectPrimary.SetActive(false);
        secondEffectSecondary.SetActive(false);
    }

    void Update()
    {
        if (currentTime == 2 && playFinalCheer == true)
        {
            playFinalCheer = false;

            AudioSource.PlayClipAtPoint(finalCrowdCheerSFX, new Vector3(0, 0, 0));
        }
    }

    IEnumerator UpdateTimer()
    {
        while (currentTime >= 1)
        {
            yield return new WaitForSeconds(1);

            currentTime--;
            //Converting timer to minutes and seconds
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            //print(currentTime);


            if (currentTime == roundTwoTransition || currentTime == roundThreeTransition || currentTime == finalRoundTransition)
            {
                IncreaseRound();
            }

            //Making a String Format.
            TimerText.text = string.Format("{0:00}  :  {1:00}", minutes, seconds);
        }
        //Once timer hits 0, player can no longer shoot
        Player_CS_EF.instance.rightCanFire = false;

        // gameOverText.gameObject.SetActive(true);
        print("Finish!");
    }

    public void TargetHit()
    {
        // Program that runs when a main target is hit
        // This will increase the score and the UI
        targetsHit++;
        //targetText.text = "Targets Hit: " + targetsHit;
    }

    public void IncreaseRound()
    {
        gameLevel++;

        if (gameLevel == 1)
        {
            roundOne = true;
        }

        else if (gameLevel == 2)
        {
            roundTwo = true;
            PlayRound1CrowdSound();
        }

        else if (gameLevel == 3)
        {
            roundThree = true;
            PlayRound2CrowdSound();
        }

        else if (gameLevel == 4)
        {
            StartCoroutine("FinalRoundWait");
            PlayRound3CrowdSound();
        }

        UpgradeCannon();
    }

    public void IncreaseTimer()
    {
        // Program that runs when a time target is hit
        // This will increase the time and the UI

        currentTime = currentTime + increaseAmount;
    }

    IEnumerator FinalRoundWait()
    {
        yield return new WaitForSeconds(2f);

        finalRound = true;
    }


    // Increase the firerate depending on targets hit
    public void UpgradeCannon()
    {

        // Make the gun turn into the three burst gun
        // Remove the rapid fire temporarily (may decide against this idea after some play testing)
        // Add new mesh
        if (currentTime <= roundTwoTransition)
        {
            gunBarrel[0].transform.parent = null;
            gunBarrel[0].GetComponent<Rigidbody>().useGravity = true;
            gunBarrel[1].transform.parent = null;
            gunBarrel[1].GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine("UpgradeGun1");
            basicCannon = false;
            threeBurstActive = true;


        }

        // Make the gun turn into the five/star burst gun
        // Add new mesh
        if (currentTime <= roundThreeTransition)
        {
            gunBarrel[2].transform.parent = null;
            gunBarrel[2].GetComponent<Rigidbody>().useGravity = true;
            gunBarrel[3].transform.parent = null;
            gunBarrel[3].GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine("UpgradeGun2");
            threeBurstActive = false;
            fiveBurstActive = true;

        }

        // Make the gun turn into a nine burst gun with rapid fire
        // Add new mesh
        if (currentTime <= finalRoundTransition)
        {
            gunBarrel[4].transform.parent = null;
            gunBarrel[4].GetComponent<Rigidbody>().useGravity = true;
            gunBarrel[5].transform.parent = null;
            gunBarrel[5].GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine("UpgradeGun3");
            fiveBurstActive = false;
            nineBurstActive = true;

        }
    }

    void ResetCannon()
    {
        attackSpeed = fireRate;
        basicCannon = true;
        threeBurstActive = false;
        fiveBurstActive = false;
        nineBurstActive = false;

    }

    IEnumerator BeginGame()
    {
        player.transform.rotation = playerGamePoint.rotation;
        player.transform.position = playerGamePoint.position;

        yield return new WaitForSeconds(5f);

        gameActive = true;

        roundOne = true;


        IncreaseRound();

        AudioSource.PlayClipAtPoint(gameBackgroundMusic, new Vector3(0, 0, 0));

        StartCoroutine("UpdateTimer");
    }

    IEnumerator UpgradeGun1()
    {

        //Show Gun upgrade text.
        textAnimator.SetBool("isUpgrading", true);
        lightAnimator.SetBool("isUpgrading", true);

        //Disable Fire Button
        Player_CS_EF.instance.canBothFire = false;

        //Activate the 1st Particle effect
        upgradeEffectPrimary.SetActive(true);
        upgradeEffectSecondary.SetActive(true);


        print("Gun Down");
        yield return new WaitForSeconds(2f);

        //Turn off current mesh
        mainCannonPrimary.SetActive(false);
        mainCannonSecondary.SetActive(false);

        //Turn on upgraded gun mesh
        threeBurstCannonPrimary.SetActive(true);
        threeBurstCannonSecondary.SetActive(true);

        StartCoroutine("Effect2");

        print("Gun Upgraded");
    }

    IEnumerator UpgradeGun2()
    {

        //Show Gun upgrade text.
        textAnimator.SetBool("isUpgrading", true);
        lightAnimator.SetBool("isUpgrading", true);

        //Disable Fire Button
        Player_CS_EF.instance.canBothFire = false;

        //Activate the 1st Particle effect
        upgradeEffectPrimary.SetActive(true);
        upgradeEffectSecondary.SetActive(true);


        print("Gun Down");
        yield return new WaitForSeconds(2f);

        //Turn off current mesh
        threeBurstCannonPrimary.SetActive(false);
        threeBurstCannonSecondary.SetActive(false);

        //Turn on upgraded gun mesh
        fiveBurstCannonPrimary.SetActive(true);
        fiveBurstCannonSecondary.SetActive(true);

        StartCoroutine("Effect2");

        print("Gun Upgraded");
    }
    IEnumerator UpgradeGun3()
    {
        //Show Gun upgrade text.
        textAnimator.SetBool("isUpgrading", true);
        lightAnimator.SetBool("isUpgrading", true);

        //Disable Fire Button
        Player_CS_EF.instance.canBothFire = false;

        //Activate the 1st Particle effect
        upgradeEffectPrimary.SetActive(true);
        upgradeEffectSecondary.SetActive(true);

        print("Gun Down");
        yield return new WaitForSeconds(2f);

        //Turn off current mesh
        fiveBurstCannonPrimary.SetActive(false);
        fiveBurstCannonSecondary.SetActive(false);

        //Turn on upgraded gun mesh
        nineBurstCannonPrimary.SetActive(true);
        nineBurstCannonSecondary.SetActive(true);

        StartCoroutine("Effect2");

        print("Gun Upgraded");
    }

    IEnumerator Effect2()
    {
        //turn off 1st effect
        upgradeEffectPrimary.SetActive(false);
        upgradeEffectSecondary.SetActive(false);


        AudioSource.PlayClipAtPoint(cannonUpgradeSFX, new Vector3(0, 0, 0));

        //turn on 2nd effect
        secondEffectPrimary.SetActive(true);
        secondEffectSecondary.SetActive(true);

        //turn off gun upgrade text
        textAnimator.SetBool("isUpgrading", false);
        lightAnimator.SetBool("isUpgrading", false);
        //enable fire button
        Player_CS_EF.instance.canBothFire = true;

        yield return new WaitForSeconds(2f);

        //turn off 2nd effect
        secondEffectPrimary.SetActive(false);
        secondEffectSecondary.SetActive(false);
    }
    public void PlayRound1CrowdSound()
    {
        int playSound = Random.Range(0, 3);
        print(playSound);

        switch (playSound)
        {
            case 0:
                AudioSource.PlayClipAtPoint(crowdCheering1SFX, new Vector3(0, 0, 0));
                break;

            case 1:
                AudioSource.PlayClipAtPoint(crowdCheering2SFX, new Vector3(0, 0, 0));
                break;

            case 2:
                AudioSource.PlayClipAtPoint(crowdCheering3SFX, new Vector3(0, 0, 0));
                break;

            default:
                break;
        }
    }
    public void PlayRound2CrowdSound()
    {
        int playSound = Random.Range(0, 3);
        print(playSound);

        switch (playSound)
        {
            case 0:
                AudioSource.PlayClipAtPoint(crowdCheering4SFX, new Vector3(0, 0, 0));
                break;

            case 1:
                AudioSource.PlayClipAtPoint(crowdCheering5SFX, new Vector3(0, 0, 0));
                break;

            case 2:
                AudioSource.PlayClipAtPoint(crowdCheering6SFX, new Vector3(0, 0, 0));
                break;

            default:
                break;
        }
    }

    public void PlayRound3CrowdSound()
    {
        int playSound = Random.Range(0, 3);
        print(playSound);

        switch (playSound)
        {
            case 0:
                AudioSource.PlayClipAtPoint(crowdCheering7SFX, new Vector3(0, 0, 0));
                break;

            case 1:
                AudioSource.PlayClipAtPoint(crowdCheering8SFX, new Vector3(0, 0, 0));
                break;

            case 2:
                AudioSource.PlayClipAtPoint(crowdCheering9SFX, new Vector3(0, 0, 0));
                break;

            default:
                break;
        }
    }
}
