using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    public GameObject dialogueButton;

    public void OnClick()
    {
        dialogueButton.SetActive(true);
        dialogueButton.GetComponent<DialogueButton>().OnClick();
        gameObject.GetComponent<Button>().interactable = false;
    }
}
