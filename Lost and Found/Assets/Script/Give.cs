using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Give : MonoBehaviour
{
    public Text displayText;
    public void OfferObject()
    {
        if(DataManager.Instance.selectedItem == null)
        {
            displayText.text = "Sorry, please select an item";
        }
        else
        {
            Student currentStudent = DataManager.Instance.currentStudent.GetComponent<Student>();
            GameObject selectedItem = DataManager.Instance.selectedItem;

            displayText.text = "";

            if (currentStudent.lostItem == selectedItem)
            {
                GameObject.FindGameObjectWithTag("CharacterButton").GetComponent<CharacterButton>().EndSuccess("Thanks! I finally found it.");
                DataManager.Instance.items.Remove(DataManager.Instance.selectedItem);
                Destroy(selectedItem);
            }
            else
            {
                if (currentStudent.honest)
                {
                    GameObject.FindGameObjectWithTag("CharacterButton").GetComponent<CharacterButton>().EndFailure("This " + DataManager.Instance.selectedItem.GetComponent<Item>().itemName + " is not mine. Seems like you are really bad with your job.");
                }
                else
                {
                    GameObject.FindGameObjectWithTag("CharacterButton").GetComponent<CharacterButton>().EndFailure("Well, I guess I can just take this anyways.");
                    DataManager.Instance.items.Remove(DataManager.Instance.selectedItem);
                    Destroy(selectedItem);
                }
            }
        }
    }
}
