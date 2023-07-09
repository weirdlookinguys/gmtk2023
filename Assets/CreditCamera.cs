using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditCamera : MonoBehaviour
{
    public float Speed = 0.5f;
    public Transform ReturnTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = Speed;
        if (Input.GetKey(KeyCode.Space))
            speed *= 30;

        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < ReturnTrigger.position.y)
            SceneManager.LoadScene("MainMenu");
    }
}
