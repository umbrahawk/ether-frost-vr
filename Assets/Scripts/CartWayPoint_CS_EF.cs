using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartWayPoint_CS_EF : MonoBehaviour
{
    // put the points from unity interface
    public Transform[] wayPointList;

    public int lastPoint;
    public int currentWayPoint = 0;
    Transform targetWayPoint;
    public int spawnTime;

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
    }

    // Update is called once per frame
    void Update()
    {
        //if (LevelManager_CS_EF.instance.currentTime <= spawnTime)
        //{
            // check if we have somewere to walk
            if (currentWayPoint < this.wayPointList.Length && cartActive)
            {
                cartActive = false;
                if (targetWayPoint == null)
                {
                    targetWayPoint = wayPointList[currentWayPoint];
                    StartCoroutine("walk");
                }
            }
        //}
        //}
    }

    IEnumerator walk()
    {


        // rotate towards the target
        //transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);


        //transform.Rotate(new Vector3(targetWayPoint.rotation.x, targetWayPoint.rotation.y, targetWayPoint.rotation.z) * Time.deltaTime * 300, Space.World);

        float startTime = Time.time;
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;
        while (transform.position != targetWayPoint.position)
        {
            float distance = Vector3.Distance(startPosition, targetWayPoint.position);
            float timeLeft = (Time.time - startTime) * speed;
            float distanceFraction = timeLeft / distance;
            transform.rotation = Quaternion.Lerp(startRotation, targetWayPoint.rotation, distanceFraction);

            // move towards the target
            //transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);
            transform.position = Vector3.Lerp(startPosition, targetWayPoint.position, distanceFraction);
            yield return null;
        }
        currentWayPoint++;
        if (currentWayPoint == lastPoint)
        {
            cartActive = false;
            targetWayPoint = null;
        }
        else
        {
            targetWayPoint = wayPointList[currentWayPoint];
            StartCoroutine("walk");

        }

        yield return null;
    }
}
