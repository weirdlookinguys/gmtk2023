using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Patrol), typeof(Animator))]
public class CharacterAnimationRotater : MonoBehaviour
{
    public string DownStateName;
    public string UpStateName;
    public string SideStateName;

    public float Threshold = 0.1f;

    private Patrol _patrol;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _patrol = GetComponent<Patrol>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float myAngle = Vector2.Angle(Vector2.right, _patrol.GetDirection());
        if ((myAngle > 315) || (myAngle < 45 && myAngle > 0) || (myAngle > 135 && myAngle < 225))
        {
            _animator.Play(SideStateName);
            bool left = _patrol.GetDirection().x < 0;
            transform.localScale = new Vector3(left ? 1 : -1, 1, 1);
        }
        else if ((myAngle > 45 && myAngle < 135) || (myAngle > 225 && myAngle < 315))
        {
            bool up = _patrol.GetDirection().y > 0;
            _animator.Play(up ? UpStateName : DownStateName);
        }
        //Debug.Log(myAngle);
    }
}
