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

    public GameEvent nextCharacter;

    public void PrepDialogue()
    {
        if (DataManager.Instance.students.Count > 0)
        {
            GetAndSaveStudent();
            nextCharacter.Raise();
            GenerateSentences(studentInfo);
        }
        else
        {
            DayGenerator.Instance.NextDay();
        }
    }

    private void GetAndSaveStudent()
    {
        student = DataManager.Instance.students[0];
        DataManager.Instance.students.RemoveAt(0);
        if (DataManager.Instance.currentStudent != null)
        {
            Destroy(DataManager.Instance.currentStudent);
        }
        DataManager.Instance.currentStudent = student;
        studentInfo = student.GetComponent<Student>();
    }

    private void GenerateSentences(Student studentInfo)
    {
        sentences.Clear();
        index = 0;
        if (studentInfo.lostItem == null)
        {
            sentences.Add("Did I ")
        }
        else
        {
            Item item = studentInfo.lostItem.GetComponent<Item>();
            sentences = new List<string>();

            int day = DataManager.Instance.day;
            if (day == 1)
            {
                GenerateForDay1(item);
            }
            else if (day == 2)
            {
                GenerateForDay2(item);
            }
            else if (day == 3)
            {
                GenerateForDay3(item);
            }
        }
    }

    private void GenerateForDay1(Item item)
    {
        sentences.Add("I lost my " + item.itemName + ". ");
        sentences.Add("Its color is " + item.color + ". ");
    }

    private void GenerateForDay2(Item item)
    {
        sentences.Add("I lost my " + item.itemName + ". ");
        sentences.Add("Its color is " + item.color + ". ");
    }
    private void GenerateForDay3(Item item)
    {
        sentences.Add("I lost my " + item.itemName + ". ");
        sentences.Add("Its color is " + item.color + ". ");
    }

    public string GetNextSentence()
    {
        if (DataManager.Instance.currentStudent.GetComponent<Student>().questionsLeft <= 0)
        {
            return "STOP ASKING QUESTIONS, JUST GIVE ME MY STUFF";
        }

        string sentence = sentences[index];
        index++;
        if (index >= sentences.Count)
        {
            index = index % sentences.Count;
        }
        Debug.Log(index);

        DataManager.Instance.currentStudent.GetComponent<Student>().questionsLeft -= 1;
        return sentence;
    }
}
