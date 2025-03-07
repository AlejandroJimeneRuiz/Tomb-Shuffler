using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animation door;
    private bool hasPlayed = false; // Variable para controlar si la animación ya se reprodujo

    // Start is called before the first frame update
    void Start()
    {
        if (door == null)
        {
            door = GetComponent<Animation>();
        }
    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E) && !hasPlayed) 
        {
            door.Play();
            hasPlayed = true; // Marcar la animación como reproducida
        }
    }
}

