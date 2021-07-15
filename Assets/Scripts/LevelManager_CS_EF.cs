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
    public float fireRate = 0.25f;

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

    [Header("VISUAL EFFECTS")]
    public GameObject upgradeEffect;

    [Header("MISC")]
    public Rigidbody[] gunBarrel;


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

        upgradeEffect.SetActive(false);
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


    public void BeginGame()
    {
        gameActive = true;

        roundOne = true;

        IncreaseRound();

        AudioSource.PlayClipAtPoint(gameBackgroundMusic, new Vector3(0, 0, 0));

        StartCoroutine("UpdateTimer");
    }

    IEnumerator UpgradeGun1()
    {
        Player_CS_EF.instance.canBothFire = false;
        upgradeEffect.SetActive(true);
        gunText.gameObject.SetActive(true);
        print("Gun Down");
        yield return new WaitForSeconds(2f);
        //Destroy(gunBarrel[0].gameObject);
        mainCannon.SetActive(false);
        threeBurstCannon.SetActive(true);
        upgradeEffect.SetActive(false);
        gunText.gameObject.SetActive(false);
        Player_CS_EF.instance.canBothFire = true;
        print("Gun Upgraded");
    }

    IEnumerator UpgradeGun2()
    {
        Player_CS_EF.instance.canBothFire = false;
        upgradeEffect.SetActive(true);
        gunText.gameObject.SetActive(true);
        print("Gun Down");
        yield return new WaitForSeconds(2f);
        threeBurstCannon.SetActive(false);
        fiveBurstCannon.SetActive(true);
        upgradeEffect.SetActive(false);
        gunText.gameObject.SetActive(false);
        Player_CS_EF.instance.canBothFire = true;
        print("Gun Upgraded");
    }
    IEnumerator UpgradeGun3()
    {
        Player_CS_EF.instance.canBothFire = false;
        upgradeEffect.SetActive(true);
        gunText.gameObject.SetActive(true);
        print("Gun Down");
        yield return new WaitForSeconds(2f);
        fiveBurstCannon.SetActive(false);
        nineBurstCannon.SetActive(true);
        upgradeEffect.SetActive(false);
        gunText.gameObject.SetActive(false);
        Player_CS_EF.instance.canBothFire = true;
        print("Gun Upgraded");
    }
}
