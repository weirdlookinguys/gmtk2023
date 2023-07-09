using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float Range = 10f;
    public float BouncePerSec = .3f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.AngleAxis(Mathf.Sin(Time.timeSinceLevelLoad * Mathf.PI * 2 * BouncePerSec) * Range, Vector3.forward);
    }
}
