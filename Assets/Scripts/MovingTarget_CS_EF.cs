using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget_CS_EF : MonoBehaviour
{
    public bool dirRight = true;
    public float speed;
    public float pivotTime;

    void Start()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        StartCoroutine("MoveRing");
    }

    // Update is called once per frame
    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else if (!dirRight)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    IEnumerator MoveRing()
    {
        if (dirRight)
        {
            yield return new WaitForSeconds(pivotTime);
        }

        else if (!dirRight)
        {
            yield return new WaitForSeconds(pivotTime);
        }

        dirRight = !dirRight;

        StartCoroutine("MoveRing");
    }
}
