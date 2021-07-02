using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheel_CS_EF : MonoBehaviour
{
    public MeshCollider myMeshCollider;
    public GameObject[] carts;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < carts.Length; i++)
        {
            Physics.IgnoreCollision(myMeshCollider, carts[i].GetComponent<Collider>());
        }
    }
}
