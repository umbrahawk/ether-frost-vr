using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneWaypoint_CS_EF : MonoBehaviour
{
    // put the points from unity interface
    public Transform[] wayPointList;

    public int currentWayPoint = 0;
    Transform targetWayPoint;
    public int spawnTime;

    public float speed;

    public bool planeActive = false;

    public static PlaneWaypoint_CS_EF instance;

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
        //if (LevelManager_CS_EF.instance.currentTime <= spawnTime)
        //{
            // check if we have somewere to walk
            if (currentWayPoint < this.wayPointList.Length)
            {
                if (targetWayPoint == null)
                    targetWayPoint = wayPointList[currentWayPoint];
                walk();
            }
        //}
        //}
    }

    public void walk()
    {


        // rotate towards the target
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);

        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        //transform.rotation = Quaternion.Lerp(transform.rotation, targetWayPoint.rotation, Time.deltaTime * 70);

        if (transform.position == targetWayPoint.position)
        {
            currentWayPoint++;
            if (currentWayPoint == 11)
            {
                planeActive = false;
                targetWayPoint = null;
            }
            else
            {
                targetWayPoint = wayPointList[currentWayPoint];
            }

        }
    }
}
