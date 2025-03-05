using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animation hingehere; 

    // Start is called before the first frame update
    void Start()
    {
        if (hingehere == null)
        {
            hingehere = GetComponent<Animation>(); 
        }
    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E)) 
        {
            hingehere.Play(); 
        }
    }
}
