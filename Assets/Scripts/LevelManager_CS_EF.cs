using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager_CS_EF : MonoBehaviour
{
    // VARIABLES
    // startingTime =
    // currentTime =
    // increaseAmount =

    [Header("GAME STATS")]
    public bool gameActive = false;
    public int gameLevel = 0;
    public bool roundOne = false;
    public bool roundTwo = false;
    public bool roundThree = false;
    public bool finalRound = false;
    public int roundTwoTransition = 93;
    public int roundThreeTransition = 67;
    public int finalRoundTransition = 35;

    [Header("TIMER STATS")]
    public float startingTime = 120;
    public float currentTime;
    public float increaseAmount = 5;
    public Text timerText;

    [Header("TARGET STATS")]
    public int targetsHit = 0;
    public Text targetText;

    [Header("PLAYER STATS")]
    public bool rapidFireActive = false;
    public float attackSpeed;
    public float fireRate = 0.5f;
    public float rapidFireRate = 0.25f;

    [Header("CANNON STATS")]
    public bool basicCannon = true;
    public bool threeBurstActive = false;
    public bool fiveBurstActive = false;
    public bool nineBurstActive = false;

    [Header("CANNON MESHES")]
    public GameObject mainCannon;
    public GameObject threeBurstCannon;
    public GameObject fiveBurstCannon;
    public GameObject nineBurstCannon;

    [Header("GUN STATS")]
    public Text gunText;

    [Header("SOUND EFFECTS")]
    public AudioClip gameBackgroundMusic;


    [Header("MISC")]
    // public Text gameOverText;


    public static LevelManager_CS_EF instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        ResetCannon();

        gunText.gameObject.SetActive(false);

        // This will need to be fixed 
        //gameOverText.gameObject.SetActive(false);

        currentTime = startingTime;

        timerText.text = "Time left: " + "2:00";

        targetText.text = "Targets hit: " + targetsHit;
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

            if (currentTime == 111)
            {
                UpgradeCannon();
            }

            if (currentTime == roundTwoTransition || currentTime == roundThreeTransition || currentTime == finalRoundTransition)
            {
                IncreaseRound();
            }

            //Making a String Format.
            timerText.text = string.Format("Time left:" + " {0:00}:{1:00}", minutes, seconds);
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
        targetText.text = "Targets Hit: " + targetsHit;
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
        }

        else if (gameLevel == 3)
        {
            roundThree = true;
        }

        else if (gameLevel == 4)
        {
            print("Final round is true");
            finalRound = true;
        }

        UpgradeCannon();
    }

    public void IncreaseTimer()
    {
        // Program that runs when a time target is hit
        // This will increase the time and the UI

        currentTime = currentTime + increaseAmount;
    }

    public void LevelGun()
    {
        //starts coroutine to enable gun text for a few seconds.
        StartCoroutine("GunPrompt");
    }

    // Increase the firerate depending on targets hit
    public void UpgradeCannon()
    {
        // Make the gun turn into rapid fire
        if (currentTime <= 111)
        {
            attackSpeed = rapidFireRate;
        }

        // Make the gun turn into the three burst gun
        // Remove the rapid fire temporarily (may decide against this idea after some play testing)
        // Add new mesh
        if (currentTime <= roundTwoTransition)
        {
            basicCannon = false;
            threeBurstActive = true;
            mainCannon.SetActive(false);
            threeBurstCannon.SetActive(true);
        }

        // Make the gun turn into the five/star burst gun
        // Add new mesh
        if (currentTime <= roundThreeTransition)
        {
            threeBurstActive = false;
            fiveBurstActive = true;
            threeBurstCannon.SetActive(false);
            fiveBurstCannon.SetActive(true);
        }

        // Make the gun turn into a nine burst gun with rapid fire
        // Add new mesh
        if (currentTime <= finalRoundTransition)
        {
            fiveBurstActive = false;
            nineBurstActive = true;
            fiveBurstCannon.SetActive(false);
            nineBurstCannon.SetActive(true);
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

    IEnumerator GunPrompt()
    {
        gunText.gameObject.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        gunText.gameObject.SetActive(false);
    }

    public void BeginGame()
    {
        gameActive = true;

        roundOne = true;

        IncreaseRound();

        AudioSource.PlayClipAtPoint(gameBackgroundMusic, new Vector3(0, 0, 0));

        StartCoroutine("UpdateTimer");
    }
}
