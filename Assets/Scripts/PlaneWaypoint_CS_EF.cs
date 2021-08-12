using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneWaypoint_CS_EF : MonoBehaviour
{
    // put the points from unity interface
    public Transform[] wayPointList;
    Transform targetWayPoint;
    public GameObject fallingTarget;
    GameObject targetLook;
    

    public int[] dropPoint;
    public int lastPoint;
    public int currentWayPoint = 0;
    public int[] spawnTime;

    public float speed;

    public bool planeActive = true;

    public static PlaneWaypoint_CS_EF instance;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        planeActive = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (LevelManager_CS_EF.instance.currentTime == spawnTime[0])
        {

            if (targetWayPoint == null && planeActive)
            {
                targetWayPoint = wayPointList[currentWayPoint];
                print("GO!");
                StartCoroutine("walk");
            }

        }
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
        for(int i = 0; i < dropPoint.Length; i++)
        {
            if (dropPoint[i] == currentWayPoint)
            {
                //spawn falling target
                targetLook = Instantiate(fallingTarget, transform.position, transform.rotation);

            }
        }
        if (currentWayPoint == lastPoint)
        {
            planeActive = false;
            print("Status of plane: " + planeActive);
            currentWayPoint = 1;
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
