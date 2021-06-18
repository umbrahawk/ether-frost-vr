using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager_CS_EF : MonoBehaviour
{
    [Header("TIMER STATS")]
    public float startingTime = 150;
    public float currentTime;
    public float increaseAmount = 5;
    public Text timerText;

    [Header("TARGET STATS")]
    public int targetsHit = 0;
    public Text targetText;

    [Header("PLAYER STATS")]
    public float fireRate = 0.5f;

    [Header("GUN STATS")]
    public Text gunText;

    [Header("MISC")]
    public Text gameOverText;


    public static LevelManager_CS_EF instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        gunText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);

        currentTime = startingTime;

        timerText.text = "Timer: " + currentTime;

        targetText.text = "Targets Hit: " + targetsHit;

        StartCoroutine("UpdateTimer");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            IncreaseTimer();
        }
    }

    IEnumerator UpdateTimer()
    {
        while (currentTime >= 1)
        {
            if(currentTime == 40)
            {
                //insert event code here
                //like gun upgrade, fireworks etc.
                print("Event 1 Ping, Gun Upgrading!");
            }

            if (currentTime == 20)
            {
                //insert event code here
                //like gun upgrade, fireworks etc.
                print("Event 2 Ping, GO CRAZY!!!");
            }
            yield return new WaitForSeconds(1);

            currentTime--;
            //Converting timer to minutes and seconds
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);
            
            //print(currentTime);
            
            //Making a String Format.
            timerText.text = string.Format("Time Remaining: " +" {0:00}:{1:00}", minutes, seconds);
        }
        //Once timer hits 0, player can no longer shoot
        Player_CS_EF.instance.canFire = false;
        gameOverText.gameObject.SetActive(true);
        print("Finish!");

    }

    public void TargetHit()
    {
        // Program that runs when a main target is hit
        // This will increase the score and the UI
        targetsHit++;
        targetText.text = "Targets Hit: " + targetsHit;

        // Checks if the required targets have been hit before upgrading the controller
        if (targetsHit == 10)
        {
            UpgradeCannon();
        }
    }

    public void IncreaseTimer()
    {
        // Program that runs when a time target is hit
        // This will increase the time and the UI

        currentTime = currentTime + increaseAmount;
        timerText.text = "Timer: " + currentTime;
    }

    public void LevelGun()
    {
        //starts coroutine to enable gun text for a few seconds.
        StartCoroutine("GunPrompt");
    }

    // Increase the firerate depending on targets hit
    public void UpgradeCannon()
    {
        if (targetsHit == 10)
        {
            fireRate = .2f;
        }
    }

    IEnumerator GunPrompt()
    {
        gunText.gameObject.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        gunText.gameObject.SetActive(false);
    }
}
