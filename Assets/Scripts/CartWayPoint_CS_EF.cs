using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartWayPoint_CS_EF : MonoBehaviour
{
    // put the points from unity interface
    public Transform[] wayPointList;

    public int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed;

    public bool cartActive = false;

    public static CartWayPoint_CS_EF instance;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        //cartActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        //only activates last vehicle.
        //if (cartActive == true)
        //{
        if (LevelManager_CS_EF.instance.targetsHit >= 2)
        {
            // check if we have somewere to walk
            if (currentWayPoint < this.wayPointList.Length)
            {
                if (targetWayPoint == null)
                    targetWayPoint = wayPointList[currentWayPoint];
                walk();
            }
        }
        //}
    }

    public void walk()
    {
        // rotate towards the target
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);

        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        if (transform.position == targetWayPoint.position )
        {
            currentWayPoint++;
            if(currentWayPoint == 11)
            {
                cartActive = false;
                targetWayPoint = null;
            }
            else
            {
                targetWayPoint = wayPointList[currentWayPoint];
            }
            
        }
    }
}
