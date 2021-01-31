using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reject : MonoBehaviour
{
    
    public void RejectCharacter()
    {
        if (DataManager.Instance.currentStudent.GetComponent<Student>().honest)
        {
            GameObject.FindGameObjectWithTag("CharacterButton").GetComponent<CharacterButton>().EndFailure("Where's my stuff? I'm pretty sure you should have it.");
        }
        else
        {
            GameObject.FindGameObjectWithTag("CharacterButton").GetComponent<CharacterButton>().EndSuccess("I guess I should also go check other places. Thanks anyways!");
        }
    }
}
