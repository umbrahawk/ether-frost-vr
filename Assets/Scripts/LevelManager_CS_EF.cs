using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager_CS_EF : MonoBehaviour
{
    [Header("TIMER STATS")]
    public int startingTime = 150;
    public int currentTime;
    public int increaseAmount = 5;
    public Text timerText;

    [Header("TARGET STATS")]
    public int targetsHit = 0;
    public Text targetText;

    [Header("GUN STATS")]
    public Text gunText;

    public static LevelManager_CS_EF instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        gunText.gameObject.SetActive(false);

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
        int t = currentTime;

        while (t > 0)
        {
            yield return new WaitForSeconds(1);

            currentTime--;

            timerText.text = "Timer: " + currentTime;
        }
    }

    public void TargetHit()
    {
        // Program that runs when a main target is hit
        // This will increase the score and the UI
        targetsHit++;
        targetText.text = "Targets Hit: " + targetsHit;
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

    IEnumerator GunPrompt()
    {
        gunText.gameObject.SetActive(true);

        yield return new WaitForSeconds(5);

        gunText.gameObject.SetActive(false); ;
    }
}
