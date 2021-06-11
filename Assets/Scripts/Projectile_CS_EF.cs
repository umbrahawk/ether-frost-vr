using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_CS_EF : MonoBehaviour
{
    Rigidbody rb;
    public int forwardSpeed = 2000;
    public int upwardSpeed = 200;
    public float lifetime = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * forwardSpeed);

        StartCoroutine("Lifetime");
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.name == "Special_EF")
        {
            print("Adding Time");
            //LevelManager_CS_EF.IncreaseTimer.
        }
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetime);

        Destroy(gameObject);
    }
}
