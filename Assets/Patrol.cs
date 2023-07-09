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
    private float viewAngle;
    public float viewDist;
    public Transform player;
    public LayerMask viewMask;

    void Start() {
        viewAngle = 90;
    }
    private void Update() {
        if (coordinates.Length == 0)
            return;

        if (!reversePath) {
            currentPoint = coordinates[currentPointIndex];
            direction = currentPoint.position - transform.position;
            direction.Normalize();

            float movementAmount = speed * Time.deltaTime;
            nextPosition = (Vector2)transform.position + (direction * movementAmount);

            transform.right = nextPosition - (Vector2)transform.position;
            transform.position = nextPosition;

            if (Vector2.Distance(transform.position, currentPoint.position) <= 0.1f) {
                currentPointIndex++;
                if (currentPointIndex >= coordinates.Length)
                    currentPointIndex = 0;
            }
        }
        else {
            //Later implementation
        }
        if (CanSeePlayer())
        {
            Debug.Log("PlayerSeen!");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * viewDist);

        Vector3 rightDir = Quaternion.Euler(0f, 0f, -viewAngle / 2f) * transform.right;
        Vector3 leftDir = Quaternion.Euler(0f, 0f, viewAngle / 2f) * transform.right;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + rightDir * viewDist);
        Gizmos.DrawLine(transform.position, transform.position + leftDir * viewDist);
    }

    bool CanSeePlayer() {
        if(Vector2.Distance(transform.position, player.position) < viewDist) {
            Vector2 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenPatrolAndPlayer = Vector2.Angle(transform.right, dirToPlayer);
            if(angleBetweenPatrolAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                    return true;
            }
        }
        return false;
    }
}
