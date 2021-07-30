using UnityEngine;

public class RotatingTable_CS_EF : MonoBehaviour
{
    public float rotateSpeed = 0.5f;

    public bool isActivated = false;
    public int spawnTime;

    public ParticleSystem smoke;
    public Renderer rend;

    [Header("TARGETS")]
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;

    void Start()
    {
        smoke = GetComponent<ParticleSystem>();

        rend = GetComponent<Renderer>();

        rend.enabled = false;
        target1.SetActive(false);
        target2.SetActive(false);
        target3.SetActive(false);
        target4.SetActive(false);
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0);
        
        if (LevelManager_CS_EF.instance.currentTime == spawnTime)
        {
            isActivated = true;

            Activate();
        }

    }

    void Activate()
    {
        smoke.Play();

        rend.enabled = true;
        target1.SetActive(true);
        target2.SetActive(true);
        target3.SetActive(true);
        target4.SetActive(true);
    }
}
