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

        // Eye tracking
        Vector2 lookingVector = Target.transform.localPosition - LeftEyePos;
        Vector2 lookingVectorRight = Target.transform.localPosition - RightEyePos;
        LeftEye.transform.localPosition = Vector2.Lerp(LeftEye.transform.localPosition, lookingVector.normalized * Radius, .125f);
        RightEye.transform.localPosition = Vector2.Lerp(RightEye.transform.localPosition, lookingVectorRight.normalized * Radius, .125f);
    }
}
