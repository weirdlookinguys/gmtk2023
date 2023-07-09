using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    // Camera Rotation
    int Direction = 1;
    float StartDirection; // Angle the camera starts at
    [SerializeField]
    float Distance, time; // How far the camera turns / how long the camera waits for when it reaches the distance
    int CurrentDistance;

    // Camera Sprites
    [SerializeField]
    Sprite[] States; // Sprites
    [SerializeField]    
    SpriteRenderer Camera;

    // Start is called before the first frame update
    void Start()
    {
        StartDirection = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Direction);
        CurrentDistance += Direction;
        if (Direction != 0 && Mathf.Abs(CurrentDistance - (Distance * Direction)) < 1) 
        {
            StartCoroutine(PauseCamera());
        }
        for (int i = 0; i < States.Length; i++)
        {
            if (Mathf.Abs(transform.eulerAngles.z - (45 * i)) < 1) Camera.sprite = States[i];
            Camera.gameObject.transform.rotation = Quaternion.identity;
        }
    }
    IEnumerator PauseCamera()
    {
        int temp = Direction;
        Direction = 0;
        yield return new WaitForSeconds(time);
        Direction = temp * -1;
    }
}
