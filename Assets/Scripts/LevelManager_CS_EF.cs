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
    public int subRound = 0;
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

    [Header("GUN UPGRADE")]
    public Animator textAnimator;
    public Animator lightAnimator;
    public GameObject effectClock;
    public GameObject effectAntiClock;
    public GameObject effect1;
    public bool canSpin = false;
    

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
    public bool finalCountdown = false;
    public AudioClip crowdCountingDownSFX;
    public float crowdVolume;

    [Header("ANNOUNCER SFX")]
    public AudioClip announcerStartSFX;
    public AudioClip announcerCongratulationsSFX;
    public AudioClip announcerNiceJobSFX;
    public AudioClip announcerPerfect1SFX;
    public AudioClip announcerPerfect2SFX;
    public AudioClip announcerTerrific1SFX;
    public AudioClip announcerTerrific2SFX;
    public AudioClip announcerAmazing1SFX;
    public AudioClip announcerAmazing2SFX;
    public AudioClip announcerUnbelievable1SFX;
    public AudioClip announcerUnbelievable2SFX;
    public AudioClip announcerWayToGo1SFX;
    public AudioClip announcerWayToGo2SFX;
    public AudioClip announcerWow1SFX;
    public AudioClip announcerWow2SFX;
    public AudioClip announcerYouDidIt1SFX;
    public AudioClip announcerYouDidIt2SFX;
    public float announcerVolume;


    [Header("VISUAL EFFECTS")]
    public GameObject upgradeEffectPrimary;
    public GameObject upgradeEffectSecondary;
    public GameObject secondEffectPrimary;
    public GameObject secondEffectSecondary;

    [Header("MISC")]
    public Rigidbody[] gunBarrel;
    public Transform playerGamePoint;
    public Animator screenTransition;
    public Text endScore;
    public bool gameEnded = false;


    public static LevelManager_CS_EF instance;

    void Start()
    {
        effectClock.SetActive(false);
        effectAntiClock.SetActive(false);
        effect1.SetActive(false);

        if (instance == null)
        {
            instance = this;
        }

        ResetCannon();

        // This will need to be fixed 
        //gameOverText.gameObject.SetActive(false);

        currentTime = startingTime;

        TimerText.text = "02  :  00";

        targetText.text = "HIT: " + targetsHit;

        upgradeEffectPrimary.SetActive(false);
        upgradeEffectSecondary.SetActive(false);
        secondEffectPrimary.SetActive(false);
        secondEffectSecondary.SetActive(false);
    }

    void Update()
    {
        if (currentTime == 0 && playFinalCheer == true)
        {
            playFinalCheer = false;

            AudioSource.PlayClipAtPoint(finalCrowdCheerSFX, player.transform.position, crowdVolume);
            AudioSource.PlayClipAtPoint(announcerCongratulationsSFX, player.transform.position, announcerVolume);
        }

        if (canSpin == true)
        {
            print("SPINNING!");
            effectClock.transform.Rotate(0, 1, 0);
            effectAntiClock.transform.Rotate(0, -1, 0);
        }

        if (currentTime == 10 && finalCountdown == false)
        {
            finalCountdown = true;

            AudioSource.PlayClipAtPoint(crowdCountingDownSFX, player.transform.position, crowdVolume);
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
        Player_CS_EF.instance.canBothFire = false;
        gameEnded = true;


        endScore.text = "Your Score: " + targetsHit.ToString();
        screenTransition.Play("ScreenTransitionEnd");
        
        // gameOverText.gameObject.SetActive(true);
        print("Finished!");
    }

    public void TargetHit()
    {
        // Program that runs when a main target is hit
        // This will increase the score and the UI
        targetsHit++;
        targetText.text = "HIT: " + targetsHit;
    }

    public void IncreaseRound()
    {
        gameLevel++;
        subRound = 1;

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
        screenTransition.Play("ScreenTransition");

        yield return new WaitForSeconds(1f);

        player.transform.rotation = playerGamePoint.rotation;
        player.transform.position = playerGamePoint.position;

        yield return new WaitForSeconds(2f);

        AudioSource.PlayClipAtPoint(announcerStartSFX, player.transform.position, announcerVolume);

        gameActive = true;

        roundOne = true;

        IncreaseRound();

        AudioSource.PlayClipAtPoint(gameBackgroundMusic, player.transform.position, 0.3f);

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

        //Turn on spinningVFX
        canSpin = true;
        effectClock.SetActive(true);
        effectAntiClock.SetActive(true);
        effect1.SetActive(true);

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

        //Turn on spinningVFX
        canSpin = true;
        effectClock.SetActive(true);
        effectAntiClock.SetActive(true);
        effect1.SetActive(true);

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
        
        //Turn on spinningVFX
        canSpin = true;
        effectClock.SetActive(true);
        effectAntiClock.SetActive(true);
        effect1.SetActive(true);

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


        AudioSource.PlayClipAtPoint(cannonUpgradeSFX, player.transform.position, 0.5f);

        //turn on 2nd effect
        secondEffectPrimary.SetActive(true);
        secondEffectSecondary.SetActive(true);

        //turn off gun upgrade text
        textAnimator.SetBool("isUpgrading", false);
        lightAnimator.SetBool("isUpgrading", false);
        //enable fire button
        Player_CS_EF.instance.canBothFire = true;

        yield return new WaitForSeconds(2f);

        //Turn on spinningVFX
        canSpin = false;
        effectClock.SetActive(false);
        effectAntiClock.SetActive(false);
        effect1.SetActive(false);

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
                AudioSource.PlayClipAtPoint(crowdCheering1SFX, player.transform.position, crowdVolume);
                break;

            case 1:
                AudioSource.PlayClipAtPoint(crowdCheering2SFX, player.transform.position, crowdVolume);
                break;

            case 2:
                AudioSource.PlayClipAtPoint(crowdCheering3SFX, player.transform.position, crowdVolume);
                break;

            default:
                break;
        }

        int announcerSound = Random.Range(0, 2);
        switch (announcerSound)
        {
            case 0:
                AudioSource.PlayClipAtPoint(announcerNiceJobSFX, player.transform.position, announcerVolume);
                break;

            case 1:
                AudioSource.PlayClipAtPoint(announcerYouDidIt2SFX, player.transform.position, announcerVolume);
                break;

            default:
                break;
        }
    }
    public void PlayRound2CrowdSound()
    {
        int playSound = Random.Range(0, 3);

        switch (playSound)
        {
            case 0:
                AudioSource.PlayClipAtPoint(crowdCheering4SFX, player.transform.position, crowdVolume);
                break;

            case 1:
                AudioSource.PlayClipAtPoint(crowdCheering5SFX, player.transform.position, crowdVolume);
                break;

            case 2:
                AudioSource.PlayClipAtPoint(crowdCheering6SFX, player.transform.position, crowdVolume);
                break;

            default:
                break;
        }

        int announcerSound = Random.Range(0, 3);
        switch (announcerSound)
        {
            case 0:
                AudioSource.PlayClipAtPoint(announcerWayToGo1SFX, player.transform.position, announcerVolume);
                break;

            case 1:
                AudioSource.PlayClipAtPoint(announcerWayToGo2SFX, player.transform.position, announcerVolume);
                break;

            case 2:
                AudioSource.PlayClipAtPoint(announcerYouDidIt1SFX, player.transform.position, announcerVolume);
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
                AudioSource.PlayClipAtPoint(crowdCheering7SFX, player.transform.position, crowdVolume);
                break;

            case 1:
                AudioSource.PlayClipAtPoint(crowdCheering8SFX, player.transform.position, crowdVolume);
                break;

            case 2:
                AudioSource.PlayClipAtPoint(crowdCheering9SFX, player.transform.position, crowdVolume);
                break;

            default:
                break;
        }

        int announcerSound = Random.Range(0, 4);
        switch (announcerSound)
        {
            case 0:
                AudioSource.PlayClipAtPoint(announcerUnbelievable1SFX, player.transform.position, announcerVolume);
                break;

            case 1:
                AudioSource.PlayClipAtPoint(announcerUnbelievable2SFX, player.transform.position, announcerVolume);
                break;

            case 2:
                AudioSource.PlayClipAtPoint(announcerTerrific1SFX, player.transform.position, announcerVolume);
                break;

            case 3:
                AudioSource.PlayClipAtPoint(announcerTerrific2SFX, player.transform.position, announcerVolume);
                break;

            default:
                break;
        }
    }
}
