using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    Transform player;
    bool isFollowingPlayer;
    // Start is called before the first frame update
    void Start()
    {
        isFollowingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowingPlayer)
        {
            Vector3 offset = (player.position - transform.position).normalized * -2f; // Adjust the offset value as desired
            Vector3 targetPosition = player.position + offset;

            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 20f);
        }

    }

    public void FollowPlayer() {
        isFollowingPlayer = true;
    }

    public void UnfollowPlayer()
    {
        isFollowingPlayer = false;
    }
}
