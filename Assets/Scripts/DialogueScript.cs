using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed = 0.05f;
    private int index;
    public bool isTyping = false;
    public bool isInRange = false;

    void Start()
    {
        dialogueText.text = string.Empty;
        gameObject.SetActive(false);  // El objeto de diálogo comienza desactivado
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
                isTyping = false;
            }
            else
            {
                NextLine();
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        gameObject.SetActive(true);
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in lines[index])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;  // El jugador está en el rango de la colisión
            StartDialogue();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;  // El jugador salió del rango
            gameObject.SetActive(false);  // Desactiva el panel de diálogo cuando sale del rango
        }
    }
}
