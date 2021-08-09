using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elephant_CS_EF : MonoBehaviour
{
    public AudioClip elephantNoise1SFX;
    public AudioClip elephantNoise2SFX;

    public bool canSound = true;

    public void Start()
    {
        canSound = true;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Projectile_CS_EF>())
        {
            if (canSound)
            {
                ElephantNoise();
            }
        }
    }

    IEnumerator ElephantCooldown()
    {
        canSound = false;

        int cooldownRange = Random.Range(2, 4);

        yield return new WaitForSeconds(cooldownRange);

        canSound = true;
    }

    public void ElephantNoise()
    {

        int playSound = Random.Range(0, 2);
        print(playSound);

        switch (playSound)
        {
            case 0:
                AudioSource.PlayClipAtPoint(elephantNoise1SFX, new Vector3(0, 0, 0));
                break;

            case 1:
                AudioSource.PlayClipAtPoint(elephantNoise2SFX, new Vector3(0, 0, 0));
                break;

            default:
                break;
        }

        StartCoroutine("ElephantCooldown");
    }
}
