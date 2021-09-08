using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockProjectile_CS_EF : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Projectile_CS_EF>())
        {
            print("DELETED!");
            Destroy(gameObject);
        }
    }
}
