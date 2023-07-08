using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isHoldingItem = false;
    bool isCollidingWithItem = false;
    public Item currentHeldItem;
    [SerializeField]
    float movementSpeed = 5f;
    // Start is called before the first frame update
    void Start(){
        currentHeldItem = null;
    }

    void Update() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

        if(isHoldingItem && Input.GetKeyDown(KeyCode.Space)){
            isHoldingItem = false;
            currentHeldItem.UnfollowPlayer();
            currentHeldItem = null;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && isCollidingWithItem) {
            if (currentHeldItem != null) {
                currentHeldItem.FollowPlayer();
                isHoldingItem = true;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Hit");
        if (collider.gameObject.CompareTag("item") && !isHoldingItem) {
            isCollidingWithItem = true;
            currentHeldItem = collider.gameObject.GetComponent<Item>();
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        Debug.Log("Hit");
        if (collider.gameObject.CompareTag("item") && !isHoldingItem) {
            isCollidingWithItem = false;
        }
    }
}
