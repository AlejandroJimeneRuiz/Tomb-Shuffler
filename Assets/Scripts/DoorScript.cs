using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject[] puzzleNuts; // Array de las tuercas del rompecabezas
    public Animator doorAnimator; // Animador de la puerta

    void Update()
    {
        bool puzzleSolved = true;
        for (int i = 0; i < puzzleNuts.Length; i++)
        {
            PuzzleNutScript nutScript = puzzleNuts[i].GetComponent<PuzzleNutScript>();
            if (!nutScript.IsCorrectlyPositioned())
            {
                puzzleSolved = false;
                break;
            }
        }

        if (puzzleSolved)
        {
            doorAnimator.SetBool("Open", true);
        }
    }
}

