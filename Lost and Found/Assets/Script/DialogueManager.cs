using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    private void Awake()
    {
        if (DialogueManager.Instance == null)
        {
            DialogueManager.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        index = 0;
        sentences = new List<string>();
}

    public GameObject student;
    public Student studentInfo;
    public int index;
    public List<string> sentences;

    public void PrepDialogue()
    {
        student = DataManager.Instance.students[0];
        DataManager.Instance.students.RemoveAt(0);
        studentInfo = student.GetComponent<Student>();
        GenerateSentences(studentInfo);
    }

    private void GenerateSentences(Student studentInfo)
    {
        Item item = studentInfo.lostItem.GetComponent<Item>();

        sentences.Add("I lost my " + item.itemName + ". ");
        sentences.Add("Its color is " + item.color + ". ");
    }

    public string GetNextSentence()
    {
        string sentence = sentences[index];
        index++;
        if (index >= sentences.Count)
        {
            index = index % sentences.Count;
        }
        Debug.Log(index);

        return sentence;
    }
}
