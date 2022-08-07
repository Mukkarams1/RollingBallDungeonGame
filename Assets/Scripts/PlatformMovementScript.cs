using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementScript : MonoBehaviour
{
    [SerializeField] Transform MovingPlatform;
    [SerializeField] Transform Position1;
    [SerializeField] Transform Position2;
    Vector3 NewPosition;
    [SerializeField] string CurrentState;
    [SerializeField] float Smooth;
    [SerializeField] float ResetTime;

    private void Start()
    {
        ChangeTarget();
    }
    private void FixedUpdate()
    {
        MovingPlatform.position = Vector3.Lerp(MovingPlatform.position, NewPosition, Smooth * Time.deltaTime);
    }
    void ChangeTarget()
    {
        if (CurrentState == "Moving to Position 1")
        {
            CurrentState = "Moving to Position 2";
            NewPosition = Position2.position;
        }
        else if (CurrentState == "Moving to Position 2")
        {
            CurrentState = "Moving to Position 1";
            NewPosition = Position1.position;
        }
        else if (CurrentState == "")
        {
            CurrentState = "Moving to Position 2";
            NewPosition = Position2.position;
        }
        Invoke("ChangeTarget", ResetTime);
    }
}
