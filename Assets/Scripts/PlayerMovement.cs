using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float NormalSpeed;
    public float SprintSpeed;
    private float MovementSpeed;
    private Vector3 Movement = new Vector3();
    [Space]
    public Transform GroundCheck;
    public LayerMask GroundMask;
    public float GroundDistance;
    public const float gravity = -9.81f;
    public bool isGrounded;
    [Space]
    public float JumpHeight;
    private Vector3 Velocity = new Vector3();
    [Space]
    public float CameraRotationLimit;
    public Transform CameraParent;
    public Transform Camera;
    public float CameraSpeed;
    private Vector3 Rotation = Vector2.zero;

    private void Update()
    {
        CameraMovement();
        Controls();
    }

    void CameraMovement()
    {
        Camera.LookAt(CameraParent.position);

        Rotation.y += Input.GetAxis("Mouse X") * CameraSpeed;
        Rotation.x -= Input.GetAxis("Mouse Y") * CameraSpeed;

        Rotation.x = Mathf.Clamp(Rotation.x, -CameraRotationLimit, CameraRotationLimit);

        CameraParent.localRotation = Quaternion.Euler(Rotation.x, 0, 0);
        transform.eulerAngles = new Vector2(0, Rotation.y);
    }

    void Controls()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && Velocity.y <= 0)
        {
            Velocity.y = -2;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        Velocity.y += gravity * Time.deltaTime;

        MovementSpeed = Input.GetKey(KeyCode.LeftShift) ? SprintSpeed : NormalSpeed;

        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;

        Movement = transform.forward * vertical + transform.right * horizontal;

        controller.Move(Velocity * Time.deltaTime);
        controller.Move(Movement);
    }
}