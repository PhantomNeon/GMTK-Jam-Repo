using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform GroundCheck;
    public PlayerJetPack playerJetPack;
    public Transform playerCameraParent;
    [Space]
    private Vector2 rotation = Vector2.zero;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    [Space]
    public float NormalSpeed;
    public float SprintSpeed;
    private float MovementSpeed;
    [Space]
    public bool isGrounded = false;
    public float GroundDistance;

    private void Start()
    {
        rotation.y = transform.eulerAngles.y;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance);

        playerJetPack.CanMove = !isGrounded;



        if (isGrounded)
        {
            MovementSpeed = Input.GetKey(KeyCode.LeftShift) ? SprintSpeed : NormalSpeed;
            Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            transform.Translate(Movement * MovementSpeed * Time.deltaTime);
        }

        CameraMovement();
    }

    void CameraMovement()
    {
        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
        playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        transform.eulerAngles = new Vector2(0, rotation.y);
    }
}