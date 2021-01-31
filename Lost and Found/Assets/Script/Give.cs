using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Give : MonoBehaviour
{
    public Text displayText;
    public GameEvent leaving;
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
                GameObject.FindGameObjectWithTag("CharacterButton").GetComponent<CharacterButton>().EndSuccess("Thanks! I finally found it");
            }
            else
            {
                GameObject.FindGameObjectWithTag("CharacterButton").GetComponent<CharacterButton>().EndFailure("Well, I guess I will just take this anyways");
            }
        }
    }
}
