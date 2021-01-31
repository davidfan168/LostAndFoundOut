using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reject : MonoBehaviour
{
    public GameEvent leaving;
    
    public void RejectCharacter()
    {
        if (DataManager.Instance.currentStudent.GetComponent<Student>().honest)
        {
            GameObject.FindGameObjectWithTag("CharacterButton").GetComponent<CharacterButton>().EndFailure("Where's my stuff???");
        }
        else
        {
            GameObject.FindGameObjectWithTag("CharacterButton").GetComponent<CharacterButton>().EndSuccess("Well, I'll come again next time.");
        }
    }
}
