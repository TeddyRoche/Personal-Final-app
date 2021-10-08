using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    [Flags] 
    public enum RotationDirection
    {
        None, 
        Horizontal = (1 << 0),
        Vertcial = (1 << 1)
    }

    [Tooltip("A multiplier to the input. Describes the Maximum speed in degrees / second. to flip vertical rotation, set Y to a negative value")]
    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private Vector2 acceleration;
    [SerializeField] private float inputLagPeriod;
    [SerializeField] private float maxVerticalAngleFromHorizon;
    [SerializeField] private RotationDirection rotationDirection;
    private Vector2 rotation;
    private Vector2 velocity;

    private Vector2 lastInputEvent;
    private float inputLagTimer;

    private void OnEnable()
    {
        velocity = Vector2.zero;
        inputLagTimer = 0;
        lastInputEvent = Vector2.zero;

        Vector3 euler = transform.localEulerAngles;

        if(euler.x >= 180)
        {
            euler.x -= 360;
        }
        euler.x = ClampVerticalAngle(euler.x);

        transform.localEulerAngles = euler;
        rotation = new Vector2(euler.y, euler.x);
    }

    private float ClampVerticalAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxVerticalAngleFromHorizon, maxVerticalAngleFromHorizon);
    }

    private Vector2 GetInput()
    {
        inputLagTimer += Time.deltaTime;

        Vector2 input = new Vector2(
            Input.GetAxis("Mouse X"),
        Input.GetAxis("Mouse Y")
        );

        if ((Mathf.Approximately(0, input.x) && Mathf.Approximately(0, input.y)) == false || inputLagTimer >= inputLagPeriod)
        {
            lastInputEvent = input;
            inputLagTimer = 0;
        }
        return lastInputEvent;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
   private void Update()
    {
        Vector2 wantedVelocity = GetInput() * sensitivity;

        if((rotationDirection & RotationDirection.Horizontal) == 0)
        {
            wantedVelocity.x = 0;
        }
        if((rotationDirection & RotationDirection.Vertcial) == 0)
        {
            wantedVelocity.y = 0;

        }

        Debug.Log(wantedVelocity);

        velocity = new Vector2(
            Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration.y * Time.deltaTime),
            Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration.y * Time.deltaTime)
            );

        rotation += velocity * Time.deltaTime;
        rotation.y = ClampVerticalAngle(rotation.y);

        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }
}
