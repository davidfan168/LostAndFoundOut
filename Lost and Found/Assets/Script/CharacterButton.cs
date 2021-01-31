using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    public GameObject dialogueButton;
    public GameObject successDialogue;
    public GameObject failureDialogue;

    public void OnClick()
    {
        dialogueButton.SetActive(true);
        dialogueButton.GetComponent<DialogueButton>().OnClick();
        gameObject.GetComponent<Button>().interactable = false;
    }

    public void DisplayMessage(string message)
    {
        dialogueButton.SetActive(true);
        gameObject.GetComponent<Button>().interactable = false;
        dialogueButton.GetComponent<DialogueButton>().SpecificMessage(message);
    }

    public void EndSuccess(string message)
    {
        successDialogue.SetActive(true);
        gameObject.GetComponent<Button>().interactable = false;
        successDialogue.GetComponent<DialogueButton>().SpecificMessage(message);
    }

    public void EndFailure(string message)
    {
        failureDialogue.SetActive(true);
        failureDialogue.GetComponent<Button>().interactable = false;
        failureDialogue.GetComponent<DialogueButton>().SpecificMessage(message);
    }
}
