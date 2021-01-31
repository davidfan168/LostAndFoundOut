using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpriteTransition : MonoBehaviour
{
    public Image head;
    public Image hair;
    public Image face;

    public void UpdateImage()
    {
        Student currentStudent = DataManager.Instance.currentStudent.GetComponent<Student>();
        head.sprite = currentStudent.head;
        hair.sprite = currentStudent.hair;
        face.sprite = currentStudent.face;
    }
}
