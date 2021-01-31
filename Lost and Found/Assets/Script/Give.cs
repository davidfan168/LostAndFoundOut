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
            if (currentStudent.lostItem == selectedItem)
            {
                displayText.text = "This is the correct item";
            }
            else
            {
                displayText.text = "This is not the correct item";
            }
        }
    }
}
