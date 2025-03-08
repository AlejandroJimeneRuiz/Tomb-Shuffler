using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCombat : MonoBehaviour
{
    public UnityEngine.UI.Button[] attackButtons; // Array to hold button references
    public GameObject[] slots; // Array to hold slot references
    public UnityEngine.UI.Button[] hitButtons; // Array to hold placement button references
    public GameObject[] enemySlots; // Array to hold enemy slot references
    public UnityEngine.UI.Button CancelAttackButton; // Button to cancel attack

    // Start is called before the first frame update
    void Start()
    {
        // Set all buttons to inactive at the start
        foreach (UnityEngine.UI.Button button in attackButtons)
        {
            button.gameObject.SetActive(false);
            button.interactable = false; // Ensure buttons are not interactable
        }
        foreach (UnityEngine.UI.Button button in hitButtons)
        {
            button.gameObject.SetActive(false);
            button.interactable = false; // Ensure buttons are not interactable
        }
        CancelAttackButton.gameObject.SetActive(false);
        CancelAttackButton.interactable = false; // Ensure buttons are not interactable
    }

    // Update is called once per frame
    void Update()
    {
        CheckAttackButtonStates();
    }

    void CheckAttackButtonStates() 
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount > 0 && slots[i].transform.GetChild(0).CompareTag("Placed"))
            {            
                attackButtons[i].gameObject.SetActive(true);
                attackButtons[i].interactable = true; // Enable button if there is a card in the slot
                attackButtons[i].onClick.AddListener(() => CheckHitButtonStates()); // Add listener to show hit buttons
                attackButtons[i].onClick.AddListener(() => CancelAttackButtonStates()); // Add listener to show cancel button
            }
            else
            {
                attackButtons[i].gameObject.SetActive(false);
                attackButtons[i].interactable = false; // Disable button if there is no card in the slot
            }
        }
    }
    void CheckHitButtonStates()
    {
        for (int i = 0; i < enemySlots.Length; i++)
        {
            if (enemySlots[i].transform.childCount > 0 && enemySlots[i].transform.GetChild(0).CompareTag("Placed"))
            {
                hitButtons[i].gameObject.SetActive(true);
                hitButtons[i].interactable = true; // Enable button if there is a card in the slot
            }
            else
            {
                hitButtons[i].gameObject.SetActive(false);
                hitButtons[i].interactable = false; // Disable button if there is no card in the slot
            }
        }
    }
    void CancelAttackButtonStates()
    {
        CancelAttackButton.gameObject.SetActive(true);
        CancelAttackButton.interactable = true; // Enable button to cancel attack
        CancelAttackButton.onClick.AddListener(() => ResetAttackButtonStates()); // Add listener to reset attack buttons
        CancelAttackButton.onClick.AddListener(() => ResetHitButtonStates()); // Add listener to reset hit buttons
        CancelAttackButton.onClick.AddListener(() => CancelAttackButtonReset()); // Add listener to reset cancel button
    }
    void ResetAttackButtonStates()
    {
        foreach (UnityEngine.UI.Button button in attackButtons)
        {
            button.gameObject.SetActive(false);
            button.interactable = false; // Ensure buttons are not interactable
        }
    }
    void ResetHitButtonStates()
    {
        foreach (UnityEngine.UI.Button button in hitButtons)
        {
            button.gameObject.SetActive(false);
            button.interactable = false; // Ensure buttons are not interactable
        }
    }
    void CancelAttackButtonReset()
    {
        CancelAttackButton.gameObject.SetActive(false);
        CancelAttackButton.interactable = false; // Ensure buttons are not interactable
    }
}
