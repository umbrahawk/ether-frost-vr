using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingSwing_CS_EF : MonoBehaviour
{
    public bool descend = true;
    public bool canMove = true;
    public bool startMove = false;

    public bool roundOne = false;
    public bool roundTwo = false;
    public bool roundThree = false;

    public float speed;
    public float pivotTime;


    public float stayTime;

    // Update is called once per frame
    void Update()
    {
        if (roundOne)
        {
            if (LevelManager_CS_EF.instance.roundOne == true && startMove == false)
            {
                startMove = true;
                StartCoroutine("MoveSwing");
            }

            if (LevelManager_CS_EF.instance.roundOne == true || LevelManager_CS_EF.instance.finalRound == true)
            {
                if (canMove)
                {
                    if (descend)
                        transform.Translate(Vector2.down * speed * Time.deltaTime);
                    else if (!descend)
                        transform.Translate(Vector2.up * speed * Time.deltaTime);
                }
            }
        }

        if (roundTwo)
        {
            if (LevelManager_CS_EF.instance.roundTwo == true && startMove == false)
            {
                startMove = true;
                StartCoroutine("MoveSwing");
            }

            if (LevelManager_CS_EF.instance.roundTwo == true || LevelManager_CS_EF.instance.finalRound == true)
            {
                if (canMove)
                {
                    if (descend)
                        transform.Translate(Vector2.down * speed * Time.deltaTime);
                    else if (!descend)
                        transform.Translate(Vector2.up * speed * Time.deltaTime);
                }
            }
        }

        if (roundThree)
        {
            if (LevelManager_CS_EF.instance.roundThree == true && startMove == false)
            {
                startMove = true;
                StartCoroutine("MoveSwing");
            }

            if (LevelManager_CS_EF.instance.roundThree == true || LevelManager_CS_EF.instance.finalRound == true)
            {
                if (canMove)
                {
                    if (descend)
                        transform.Translate(Vector2.down * speed * Time.deltaTime);
                    else if (!descend)
                        transform.Translate(Vector2.up * speed * Time.deltaTime);
                }
            }
        }
    }

    IEnumerator MoveSwing()
    {
        if (descend)
        {
            yield return new WaitForSeconds(pivotTime);
        }

        else if (!descend)
        {
            yield return new WaitForSeconds(pivotTime);
        }

        canMove = false;

        yield return new WaitForSeconds(stayTime);

        canMove = true;

        descend = !descend;

        StartCoroutine("MoveSwing");
    }
}
