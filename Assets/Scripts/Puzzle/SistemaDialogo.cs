using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class SistemaDialogo : MonoBehaviour
{
    public TextMeshProUGUI textoDialogo;
    public float textSpeed = 0.05f;
    private int index;
    private bool dialogoEnCurso = false;
    private bool pausa = false;
    private string[] lines; // Moved lines declaration here

    public UnityEvent OnDialogoIniciado;
    public UnityEvent OnDialogoFinalizado;

    private Dictionary<string, string[]> dialogues = new Dictionary<string, string[]>();

    public void AddDialogue(string dialogueID, string[] lines)
    {
        dialogues.Add(dialogueID, lines);
    }

    public void ShowDialogue(string dialogueID)
    {
        if (!dialogues.ContainsKey(dialogueID))
        {
            Debug.LogError("Dialogue with ID '" + dialogueID + "' not found!");
            return;
        }

        if (!dialogoEnCurso)
        {
            dialogoEnCurso = true;
            textoDialogo.text = "";
            index = 0;
            this.lines = dialogues[dialogueID]; // Assign lines here
            OnDialogoIniciado.Invoke();
            StartCoroutine(TypeLine());
        }
    }

    public void ResetDialogue()
    {
        StopAllCoroutines();
        textoDialogo.text = "";
        index = 0;
        dialogoEnCurso = false;
        pausa = false;
        lines = null; //Added to clear lines after dialogue ends.
    }

    public bool EstaDialogoActivo()
    {
        return dialogoEnCurso;
    }

    public void PausarDialogo()
    {
        pausa = !pausa;
    }

    public void SaltarDialogo()
    {
        StopAllCoroutines();
        if (lines != null && index < lines.Length)
        {
            textoDialogo.text = lines[index];
            index = lines.Length;
        }
        ResetDialogue();
    }

    public void AjustarVelocidadTexto(float nuevaVelocidad)
    {
        textSpeed = nuevaVelocidad;
        if (dialogoEnCurso)
        {
            StopAllCoroutines();
            StartCoroutine(TypeLine());
        }
    }

    IEnumerator TypeLine()
    {
        if (lines == null || index >= lines.Length)
        {
            ResetDialogue();
            yield break;
        }

        foreach (char c in lines[index].ToCharArray())
        {
            if (!pausa)
            {
                textoDialogo.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            else
            {
                yield return null;
            }
        }
        index++;
        if (index < lines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogoEnCurso = false;
            OnDialogoFinalizado.Invoke();
        }
    }
}
