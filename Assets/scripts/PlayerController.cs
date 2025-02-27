using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float movementSpeed;
    public Vector2 sensitivity;
    public new Transform camera; 
    public float jumpForce = 5f; 
    private bool isGrounded;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void UptdateMovement()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;
        if (hor != 0 || ver != 0)
        {
            Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;

            velocity = direction * movementSpeed;
        }
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; 
        }
    }

    private void UptateMouse()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if (hor != 0)
        {
        }
        transform.Rotate(0, hor * sensitivity.x, 0);

        if (ver != 0)
        {
            Vector3 rotation = camera.localEulerAngles;
            rotation.x = (rotation.x - ver * sensitivity.y + 360) % 360;
            if (rotation.x > 60 && rotation.x < 180) { rotation.x = 60; } 
            else if (rotation.x < 300 && rotation.x > 180) { rotation.x = 300; }

            camera.localEulerAngles = rotation;

        }
    }

    void Update()
    {
        UptdateMovement();
        UptateMouse();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
        }
    }
}


