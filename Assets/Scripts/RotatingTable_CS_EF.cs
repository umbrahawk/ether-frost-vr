using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTable_CS_EF : MonoBehaviour
{
    public float rotateSpeed = 0.5f;

    public bool updateSpeed = false;

    public bool isActivated = false;
    public int spawnTime;

    public ParticleSystem smoke;
    public Renderer rend;

    [Header("TARGETS")]
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public GameObject target5;
    public GameObject target6;
    public GameObject target7;
    public GameObject target8;

    void Start()
    {
        smoke = GetComponent<ParticleSystem>();

        rend = GetComponent<Renderer>();

        rend.enabled = false;
        target1.SetActive(false);
        target2.SetActive(false);
        target3.SetActive(false);
        target4.SetActive(false);
        target5.SetActive(false);
        target6.SetActive(false);
        target7.SetActive(false);
        target8.SetActive(false);
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);

        if (LevelManager_CS_EF.instance.currentTime == spawnTime)
        {
            isActivated = true;

            Activate();
        }

        if (LevelManager_CS_EF.instance.finalRound && !updateSpeed)
        {
            updateSpeed = true;

            rotateSpeed = 1f;

            target5.SetActive(true);
            target6.SetActive(true);
            target7.SetActive(true);
            target8.SetActive(true);
        }

    }

    void Activate()
    {
        smoke.Play();

        rend.enabled = true;

        StartCoroutine("DelayedStart");
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(1f);

        target1.SetActive(true);
        target2.SetActive(true);
        target3.SetActive(true);
        target4.SetActive(true);
    }
}
