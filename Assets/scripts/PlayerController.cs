using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float movementSpeed;
    public Vector2 sensitivity;//Nombrar sensiblidad
    public new Transform camera; //Nombrar a la cámara
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;//con esto el ratón desaparece de la escena
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
    }

    private void UptateMouse()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if (hor != 0) {
        }
        transform.Rotate(0, hor * sensitivity.x, 0);

        if (ver != 0)
        {
            Vector3 rotation = camera.localEulerAngles;
            rotation.x = (rotation.x - ver * sensitivity.y + 360) % 360; //Determina el rango de movimiento de cámara
            if (rotation.x > 60 && rotation.x < 180) { rotation.x = 60; } //el if y el else determina el ángulo de giro máximo de cámara
            else if(rotation.x<300 && rotation.x>180) { rotation.x = 300; }

            camera.localEulerAngles = rotation;
                
         }
        
          
    }

      
    
    void Update()
    {
     UptdateMovement();
     UptateMouse();
    }

    }

