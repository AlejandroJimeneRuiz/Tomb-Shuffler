using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour
{
    public Component doorcolliderhere;
    public GameObject keygone;

    void Start()
    {
        if (doorcolliderhere == null)
        {
            Debug.LogWarning("doorcolliderhere no est� asignado. Aseg�rate de asignarlo en el Inspector.");
        }

        if (keygone == null)
        {
            Debug.LogWarning("keygone no est� asignado. Aseg�rate de asignarlo en el Inspector.");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (doorcolliderhere != null)
            {
                doorcolliderhere.GetComponent<BoxCollider>().enabled = true;
                Debug.Log("La puerta ahora est� desbloqueada.");
            }

            if (keygone != null)
            {
                keygone.SetActive(false); 
                Debug.Log("La llave ha desaparecido.");
            }
        }
    }
}