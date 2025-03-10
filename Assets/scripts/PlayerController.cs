using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float movementSpeed;
    public Vector2 sensitivity;
    public new Transform camera; 
    public float jumpForce = 5f; 
    public bool isGrounded;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        isGrounded = true;
    }
    
    private void UpdateMovement()
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
            Debug.Log("Jump");
        }
    }

    private void UpdateMouse()
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
        UpdateMovement();
        UpdateMouse();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grounded")) 
        {
            isGrounded = true;
        }
    }
}
