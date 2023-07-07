using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isHoldingItem = false;
    private float movementSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Hit");
        //if (collision.gameObject.CompareTag("item")) {
            //ScriptItem scriptItem = collision.gameObject.GetComponent<ScriptItem>();
            //if (scriptItem != null) {
               // scriptItem.FollowPlayer();
                //isHoldingItem = true;
           // }
        //}
    }
}
