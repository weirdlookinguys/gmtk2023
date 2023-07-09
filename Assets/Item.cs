using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    Transform player;
    bool isFollowingPlayer;
    bool isJamInCase = false;
    bool isJamInBaggage = false;
    // Start is called before the first frame update
    void Start()
    {
        isFollowingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
/*        if (isFollowingPlayer)
        {
            Vector3 offset = (player.position - transform.position).normalized * -2f; // Adjust the offset value as desired
            Vector3 targetPosition = player.position + offset;

            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 20f);
        }*/
        if(isJamInCase && isJamInBaggage)
        {
            enabled = false;
        }
    }

    public void FollowPlayer() {
        isFollowingPlayer = true;
    }

    public void UnfollowPlayer()
    {
        isFollowingPlayer = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Item hit trigger");
        if (collider.gameObject.CompareTag("jampile"))
        {
            collider.gameObject.SetActive(false);
            isJamInCase = true;
        }

        if (collider.gameObject.CompareTag("baggage") && isJamInCase)
        {
            Debug.Log("Baggage hit trigger");
            isJamInBaggage = true;
            this.gameObject.tag = "Untagged";
            this.gameObject.SetActive(false);
            
            //collider.gameObject.SetActive(false);
            //isJamInCase = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("No longer hit");
        if (collider.gameObject.CompareTag("item"))
        {
            //isCollidingWithItem = false;
        }
    }
}
