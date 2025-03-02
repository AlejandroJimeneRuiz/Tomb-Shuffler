
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float movementSpeed;
    public float jumpForce = 5f; // Fuerza del salto
    public Vector2 sensitivity;
    public new Transform camera;

    private bool isGrounded; // Variable para comprobar si est� en el suelo

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
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
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) // Si presiona salto y est� en el suelo
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Se desactiva hasta que toque el suelo de nuevo
        }
    }

    private void UpdateMouse()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

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
        Jump(); // Llamamos a la funci�n de salto
        UpdateMouse();
    }

    // Verifica si el jugador est� en el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Suelo debe tener la etiqueta "Ground"
        {
            isGrounded = true;
        }
    }
}
