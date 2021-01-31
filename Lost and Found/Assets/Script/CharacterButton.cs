using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    public GameObject dialogueButton;
    public GameObject storageButton;
    public GameObject successDialogue;
    public GameObject failureDialogue;

    public void OnClick()
    {
        dialogueButton.SetActive(true);
        dialogueButton.GetComponent<DialogueButton>().OnClick();
        storageButton.GetComponent<Button>().enabled = false;
        gameObject.GetComponent<Button>().enabled = false;
    }

    public void DisplayMessage(string message)
    {
        dialogueButton.SetActive(true);
        gameObject.GetComponent<Button>().enabled = false;
        storageButton.GetComponent<Button>().enabled = false;
        dialogueButton.GetComponent<DialogueButton>().SpecificMessage(message);
    }

    public void EndSuccess(string message)
    {
        successDialogue.SetActive(true);
        gameObject.GetComponent<Button>().enabled = false;
        storageButton.GetComponent<Button>().enabled = false;
        successDialogue.GetComponent<EndingDialogue>().SpecificMessage(message);
    }

    public void EndFailure(string message)
    {
        failureDialogue.SetActive(true);
        gameObject.GetComponent<Button>().enabled = false;
        storageButton.GetComponent<Button>().enabled = false;
        failureDialogue.GetComponent<EndingDialogue>().SpecificMessage(message);
    }
}
