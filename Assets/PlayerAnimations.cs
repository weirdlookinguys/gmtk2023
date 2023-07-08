using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // Sprite flipping
    [SerializeField]
    SpriteRenderer[] Parts, PartsBack; // body, eyeR, eyeL, legR, legL, armR, armL (butt replaces eyes in back)
    [SerializeField]
    Vector3[] FlipPosition, FlipPositionBack;
    Vector3[] StartingPosition, StartingPositionBack;
    [SerializeField]
    GameObject Front, Back;
    // What direction the player is facing
    int x = 1, y = 1;

    // Grabbing
    [SerializeField]
    Vector3[] GrabPosition, GrabPositionBack;

    // Animations
    [SerializeField]
    Animator anim, animL, animBack, animBackL;
    [SerializeField]
    float Speed, Magnitude;

    // Eye tracking
    [SerializeField]
    GameObject LeftEye, RightEye;
    Vector3 LeftEyePos, RightEyePos; // Starting positions
    [SerializeField]
    float Radius; // Distance away from the eye starting positions
    [SerializeField]
    GameObject Target; // What the eyes are looking at

    // Start is called before the first frame update
    void Start()
    {
        // Get starting positions for forward/backward sprites
        StartingPosition = new Vector3[Parts.Length];
        for (int i = 0; i < Parts.Length; i++) {
            StartingPosition[i] = Parts[i].gameObject.transform.localPosition;
        }
        StartingPositionBack = new Vector3[PartsBack.Length];
        for (int i = 0; i < PartsBack.Length; i++)
        {
            StartingPositionBack[i] = PartsBack[i].gameObject.transform.localPosition;
        }

        // Set initial eye positions
        LeftEyePos = LeftEye.transform.localPosition;
        RightEyePos = RightEye.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Inputs
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Save directions
        x = horizontalInput != 0 ? ((int)horizontalInput) : x;
        y = verticalInput != 0 ? ((int)verticalInput) : y;

        // Set forward/backward facing direction
        Back.SetActive(y == 1);
        Front.SetActive(y == -1);

        // Flip sprites left/right
        if (Front.activeSelf)
        {
            // Flip front parts and adjust locations
            for (int i = 0; i < Parts.Length; i++)
            {
                Parts[i].flipX = x == -1;
                if (x == -1) Parts[i].gameObject.transform.localPosition = FlipPosition[i];
                else Parts[i].gameObject.transform.localPosition = StartingPosition[i];
            }
        }
        else
        {
            // Flip back parts and adjust locations
            for (int i = 0; i < PartsBack.Length; i++)
            {
                PartsBack[i].flipX = x == 1;
                if (x == 1) PartsBack[i].gameObject.transform.localPosition = FlipPositionBack[i];
                else PartsBack[i].gameObject.transform.localPosition = StartingPositionBack[i];
            }
        }

        // Walking animation
        bool isMoving = horizontalInput != 0 || verticalInput != 0;
        anim.SetBool("isMoving", isMoving);
        animBack.SetBool("isMoving", isMoving);
        animL.SetBool("isMoving", isMoving);
        animBackL.SetBool("isMoving", isMoving);
        if (isMoving) 
        {
            Parts[0].gameObject.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(0, Mathf.Sin(Time.time * Speed) * Magnitude, 0), .25f);
            PartsBack[0].gameObject.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(0, Mathf.Sin(Time.time * Speed) * Magnitude, 0), .25f);
        }

        // Eye tracking
        Vector2 lookingVector = Target.transform.localPosition - LeftEyePos;
        Vector2 lookingVectorRight = Target.transform.localPosition - RightEyePos;
        LeftEye.transform.localPosition = Vector3.Lerp(LeftEye.transform.localPosition, new Vector3(lookingVector.normalized.x * Radius, lookingVector.normalized.y * Radius, LeftEyePos.z), .025f);
        RightEye.transform.localPosition = Vector3.Lerp(RightEye.transform.localPosition, new Vector3(lookingVectorRight.normalized.x * Radius, lookingVectorRight.normalized.y * Radius, RightEyePos.z), .025f);
    }
}
