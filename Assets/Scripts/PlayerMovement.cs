using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    [Space]
    public float NormalSpeed;
    public float SprintSpeed;
    private float MovementSpeed;
    private Vector3 Movement = new Vector3();

    private void Update()
    {
        MovementSpeed = Input.GetKey(KeyCode.LeftShift) ? SprintSpeed : NormalSpeed;

        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * MovementSpeed;

        Movement = transform.forward * vertical + transform.right * horizontal;

        controller.Move(Movement);
    }
}