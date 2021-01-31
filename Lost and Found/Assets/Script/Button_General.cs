using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_General : MonoBehaviour
{
    // Start is called before the first frame update
    public Image img;

    public GameObject dialogueButton;
    public GameObject storageButton;

    void Start()
    {
        img = gameObject.GetComponent<Image>();
        img.alphaHitTestMinimumThreshold = 0.01f;
        storageButton = GameObject.FindGameObjectWithTag("StorageButton");
    }

    // Update is called once per frame
    public void getAppearance()
    {
        Item item = DataManager.Instance.currentStudent.GetComponent<Student>().lostItem.GetComponent<Item>();
        dialogueButton.SetActive(true);
        storageButton.GetComponent<Button>().enabled = false;
        string message = "It is " + item.type + ".";
        dialogueButton.GetComponent<DialogueButton>().SpecificMessage(message);
    }

    public void getProcess()
    {
        Item item = DataManager.Instance.currentStudent.GetComponent<Student>().lostItem.GetComponent<Item>();
        dialogueButton.SetActive(true);
        storageButton.GetComponent<Button>().enabled = false;
        string message = "I lost it at " + item.location + ".";
        dialogueButton.GetComponent<DialogueButton>().SpecificMessage(message);
    }
    public void getYou()
    {
        string name = DataManager.Instance.currentStudent.GetComponent<Student>().name;
        dialogueButton.SetActive(true);
        storageButton.GetComponent<Button>().enabled = false;
        string message = "I am " + name;
        dialogueButton.GetComponent<DialogueButton>().SpecificMessage(message);
    }

}
