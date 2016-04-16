using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class BossMove : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    private int currentPoint;


    void Start()
    {   // Setup the array patrol point
        transform.position = patrolPoints[0].position;
        currentPoint = 0;
    }

    void Update()
    {

        // Setup movement of enemy
        if (transform.position == patrolPoints[currentPoint].position)
        {
            currentPoint++;
        }

        if (currentPoint >= patrolPoints.Length)
        {
            currentPoint = 0;

        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
    }
    

    }

