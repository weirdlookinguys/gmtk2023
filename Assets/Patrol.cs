using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] coordinates;
    public float speed = 5f;
    private int currentPointIndex = 0;
    private Transform currentPoint;
    private Vector2 direction;
    private Vector2 nextPosition;
    public bool reversePath = false;
    void Start()
    {

    }
    private void Update()
    {
        if (coordinates.Length == 0)
            return;
        if (!reversePath){
            currentPoint = coordinates[currentPointIndex];
            direction = currentPoint.position - transform.position;
            direction.Normalize();

            float movementAmount = speed * Time.deltaTime;
            nextPosition = (Vector2)transform.position + (direction * movementAmount);

            transform.position = nextPosition;

            if (Vector2.Distance(transform.position, currentPoint.position) <= 0.1f)
            {
                currentPointIndex++;
                if (currentPointIndex >= coordinates.Length)
                    currentPointIndex = 0;
            }
        }
        else {
            //Add code here
        }
    }
}
