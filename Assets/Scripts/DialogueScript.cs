using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed = 0.05f;
    private int index;
    private bool isTyping = false;

    void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
}


