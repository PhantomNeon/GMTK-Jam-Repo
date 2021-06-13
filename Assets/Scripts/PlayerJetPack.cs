using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJetPack : MonoBehaviour
{


    public float JetSpeed = 0.1f;
    public float maxspeed = 1.5f;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody rb;
    public bool CanMove = true;

    private void Start()
    {
          rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = CanMove ? JetSpeed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = CanMove ? JetSpeed * Input.GetAxis("Horizontal") : 0;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        
        moveDirection = Vector3.ClampMagnitude(moveDirection, maxspeed);

        if (CanMove)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = JetSpeed;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection.y = -JetSpeed;
            }
        }

        rb.AddForce(moveDirection, ForceMode.Impulse);
    }
}
