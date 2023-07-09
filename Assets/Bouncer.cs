using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float Range = 10f;
    public float BouncePerSec = .3f;

    private Vector3 _originalPos;

    private void Start()
    {
        _originalPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = _originalPos + Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * Mathf.PI * 2 * BouncePerSec) * Range;
    }
}
