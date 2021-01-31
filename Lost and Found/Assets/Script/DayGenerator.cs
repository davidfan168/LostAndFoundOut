using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DayGenerator : MonoBehaviour
{
    public static DayGenerator Instance;
    private void Awake()
    {
        if (DayGenerator.Instance == null)
        {
            DayGenerator.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    List<GameObject> students = new List<GameObject>();
    List<GameObject> items = new List<GameObject>();
    public Canvas canvas;
    public GameObject bin;

    void Start()
    {
        GenerateDay();
    }

    private void GenerateDay()
    {
        int day = DataManager.Instance.day;

        if (day == 1)
        {
            GenerateFirstDay();
        }

        if (day == 2)
        {
            GenerateSecondDay();
        }

        if (day == 3)
        {
            GenerateThirdDay();
        }

    }

    private void GenerateFirstDay()
    {
        GameObject key = ItemGenerator.Instance.getRandomKey();
        GenerateStudentAndItem(key);
        GameObject glasses = ItemGenerator.Instance.getRandomGlasses();
        GenerateStudentAndItem(glasses);
        GameObject waterBottle = ItemGenerator.Instance.getRandomWaterBottle();
        GenerateStudentAndItem(waterBottle);

        StoreGeneratedEntities();
        InitializeStorageCabin();

        DisplayFirstCharacter();
    }

    private void GenerateSecondDay()
    {
        int trueStudentCount = 3;
        int fakeItemCount = 2;
        int lyingStudentCount = 2;

        for (int i = 0; i < trueStudentCount; i++)
        {
            GenerateStudentAndItemEasy();
        }

        for (int i = 0; i < fakeItemCount; i++)
        {
            GenerateFakeItemEasy();
        }

        for (int i = 0; i < lyingStudentCount; i++)
        {
            GenerateLyingStudentEasy();
        }

        StoreGeneratedEntities();
        InitializeStorageCabin();

        DisplayFirstCharacter();
    }

    private void GenerateThirdDay()
    {
        int trueStudentCount = 3;
        int fakeItemCount = 2;
        int lyingStudentCount = 2;

        for (int i = 0; i < trueStudentCount; i++)
        {
            GenerateStudentAndItemMedium();
        }

        for (int i = 0; i < fakeItemCount; i++)
        {
            GenerateFakeItemEasy();
        }

        for (int i = 0; i < lyingStudentCount; i++)
        {
            GenerateLyingStudentMedium();
        }

        StoreGeneratedEntities();
        InitializeStorageCabin();

        DisplayFirstCharacter();
    }

    private void GenerateStudentAndItemEasy()
    {
        GameObject student = StudentGenerator.Instance.GenerateStudent();
        GameObject item;
        do
        {
            item = ItemGenerator.Instance.getRandomItemEasy();
        }
        while (hasSimilarObject(item));

        Student std = student.GetComponent<Student>();
        std.lostItem= item;
        std.honest = true;

        items.Add(item);
        students.Add(student);
    }

    private void GenerateStudentAndItemMedium()
    {
        GameObject student = StudentGenerator.Instance.GenerateStudent();
        GameObject item;
        do
        {
            item = ItemGenerator.Instance.getRandomItemEasy();
        }
        while (hasIdenticalObject(item));

        Student std = student.GetComponent<Student>();
        std.lostItem = item;
        std.honest = true;

        items.Add(item);
        students.Add(student);
    }

    private void GenerateStudentAndItem(GameObject item)
    {
        GameObject student = StudentGenerator.Instance.GenerateStudent();

        Student std = student.GetComponent<Student>();
        std.lostItem = item;
        std.honest = true;

        items.Add(item);
        students.Add(student);
    }

    private void GenerateFakeItemEasy()
    {
        GameObject item;
        do
        {
            item = ItemGenerator.Instance.getRandomItemEasy();
        }
        while (hasSimilarObject(item));

        GameObject obj = Instantiate(item);
        items.Add(obj);
    }

    private void GenerateLyingStudentEasy()
    {
        GameObject student = StudentGenerator.Instance.GenerateStudent();
        GameObject item;
        do
        {
            item = ItemGenerator.Instance.getRandomItemEasy();
        }
        while (hasSimilarObject(item));

        Student std = student.GetComponent<Student>();
        std.lostItem = item;
        std.honest = false;

        students.Add(student);
    }

    private void GenerateLyingStudentMedium()
    {
        GameObject student = StudentGenerator.Instance.GenerateStudent();
        GameObject item;
        do
        {
            item = ItemGenerator.Instance.getRandomItemEasy();
        }
        while (hasIdenticalObject(item));

        Student std = student.GetComponent<Student>();
        std.lostItem = item;
        std.honest = false;

        students.Add(student);
    }

    private bool hasSimilarObject(GameObject thisItem)
    {
        Item thisItemInfo = thisItem.GetComponent<Item>();
        foreach (GameObject item in items)
        {
            Item itemInfo = item.GetComponent<Item>();

            if (itemInfo.itemName == thisItemInfo.itemName && itemInfo.color == thisItemInfo.color && itemInfo.type == thisItemInfo.type)
            {
                return true;
            }
        }
        return false;
    }

    private bool hasIdenticalObject(GameObject thisItem)
    {
        Item thisItemInfo = thisItem.GetComponent<Item>();
        foreach (GameObject item in items)
        {
            Item itemInfo = item.GetComponent<Item>();

            if (itemInfo.itemName == thisItemInfo.itemName && itemInfo.color == thisItemInfo.color && itemInfo.type == thisItemInfo.type && itemInfo.date == thisItemInfo.date && itemInfo.location == thisItemInfo.location)
            {
                return true;
            }
        }
        return false;
    }

    private void StoreGeneratedEntities()
    {
        items = items.OrderBy(a => Guid.NewGuid()).ToList();
        DataManager.Instance.addItems(items);
        students = students.OrderBy(a => Guid.NewGuid()).ToList();
        DataManager.Instance.setStudents(students);
    }

    private void InitializeStorageCabin()
    {
        items = DataManager.Instance.items;
        foreach (GameObject item in items)
        {
            Quaternion q = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
            Vector3 v = new Vector3(UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-50, 50), 0);
            item.transform.rotation = q;
            item.transform.position = v;
            item.transform.SetParent(bin.transform, false);
            item.GetComponent<DraggableItem>().canvas = canvas;
        }
    }

    private void DisplayFirstCharacter()
    {
        DialogueManager.Instance.PrepDialogue();
    }

    public void NextDay()
    {
        DataManager.Instance.day += 1;
        Debug.Log("Day: " + DataManager.Instance.day);
        GenerateDay();
    }
}
