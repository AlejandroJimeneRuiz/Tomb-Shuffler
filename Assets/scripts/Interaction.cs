
using UnityEngine;
using TMPro;
public class Interaction : MonoBehaviour
{
    public Camera PlayerCamera;
    public float InteractionDistance = 2f;
    public GameObject InteractionText;
    private interaction_objects currentInteractable;
    public GameObject cardCanvas;

    // Update is called once per frame
    void Update()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, InteractionDistance))
        {
            interaction_objects interaction_Objects = hit.collider.GetComponent<interaction_objects>();
            if (interaction_Objects != null && interaction_Objects != currentInteractable)
            { 
                currentInteractable = interaction_Objects;
                InteractionText.SetActive(true);
                cardCanvas.SetActive(true);
                TextMeshProUGUI textComponent = InteractionText.GetComponent<TextMeshProUGUI>();
                if (textComponent != null) 
                {
                 textComponent.text = currentInteractable.GetInteractionText();
                }

            }
        }

        else
        {
            currentInteractable=null;
            cardCanvas.SetActive(false);
            InteractionText.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
        
    }
}
