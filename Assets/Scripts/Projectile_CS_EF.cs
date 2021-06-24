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

        // rb.AddForce(transform.forward * forwardSpeed);

        MoveForward();
    }

    /*public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<MainTarget_CS_EF>())
        {
            LevelManager_CS_EF.instance.TargetHit();
        }

        if (other.gameObject.GetComponent<TimeTarget_CS_EF>())
        {
            LevelManager_CS_EF.instance.IncreaseTimer();
        }
    }
    */

    void MoveForward()
    {
        // This will shoot forward regardless of where the target is looking, needs to be fixed
        rb.AddForce(transform.forward * forwardSpeed);

        StartCoroutine("Lifetime");
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetime);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<MainTarget_CS_EF>())
        {
            Destroy(gameObject);
        }

        if (other.gameObject.GetComponent<TimeTarget_CS_EF>())
        {
            Destroy(gameObject);
        }
    }
}
