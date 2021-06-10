using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager_CS_EF : MonoBehaviour
{
    public int startingTime = 150;
    public int currentTime;
    public int increaseAmount = 5;
    public Text timerText;
    public static LevelManager_CS_EF instance;

    void Start()
    {
        currentTime = startingTime;

        timerText.text = "Timer: " + currentTime;

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

    void IncreaseTimer()
    {
        currentTime = currentTime + increaseAmount;
        timerText.text = "Timer: " + currentTime;
    }
}
