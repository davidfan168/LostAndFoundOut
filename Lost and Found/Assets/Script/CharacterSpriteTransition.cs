using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpriteTransition : MonoBehaviour
{
    public Image head;
    public Image hair;
    public Image face;
    public Image body;

    public AudioClip clip;
    private AudioSource source;

    private void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    public void UpdateImage()
    {
        Debug.Log("Updating Image");
        Student currentStudent = DataManager.Instance.currentStudent.GetComponent<Student>();
        head.sprite = currentStudent.head;
        hair.sprite = currentStudent.hair;
        face.sprite = currentStudent.face;
        body.sprite = currentStudent.body;

        source.PlayOneShot(clip, 1);
    }
}
