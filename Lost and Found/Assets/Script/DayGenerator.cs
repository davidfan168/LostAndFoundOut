﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayGenerator : MonoBehaviour
{
    List<GameObject> students = new List<GameObject>();
    List<GameObject> items = new List<GameObject>();
    public Canvas canvas;
    public GameObject bin;

    void Awake()
    {
        if(DataManager.Instance.day == 1)
        {
            GenerateForDay1();
        }
    }

    private void GenerateForDay1()
    {
        int trueStudentCount = 2;
        int fakeItemCount = 0;
        int lyingStudentCount = 0;

        for (int i = 0; i < trueStudentCount; i++)
        {
            GenerateStudentAndItem();
        }

        for (int i = 0; i < fakeItemCount; i++)
        {
            GenerateFakeItem();
        }

        for (int i = 0; i < lyingStudentCount; i++)
        {
            GenerateLyingStudent();
        }

        StoreGeneratedEntities();
        InitializeStorageCabin();

        DisplayFirstCharacter();
    }
    private void GenerateStudentAndItem()
    {
        GameObject student = StudentGenerator.Instance.GenerateStudent();
        GameObject item = ItemGenerator.Instance.getRandomItem();

        Student std = student.GetComponent<Student>();
        std.lostItem= item;
        std.honest = true;

        items.Add(item);
        students.Add(student);
    }

    private void GenerateFakeItem()
    {
        GameObject item = ItemGenerator.Instance.getRandomItem();

        GameObject obj = Instantiate(item);
        items.Add(obj);
    }

    private void GenerateLyingStudent()
    {
        GameObject student;
        do
        {
            student = StudentGenerator.Instance.GenerateStudent();
        }
        while (NotValidStudent(student));

        Student std = student.GetComponent<Student>();
        std.honest = false;

        students.Add(student);
    }

    private bool NotValidStudent(GameObject std)
    {
        return false;
    }

    private void StoreGeneratedEntities()
    {
        DataManager.Instance.addItems(items);
        DataManager.Instance.setStudents(students);
    }

    private void InitializeStorageCabin()
    {
        items = DataManager.Instance.items;
        foreach (GameObject item in items)
        {
            Quaternion q = Quaternion.Euler(0, 0, Random.Range(0, 360));
            Vector3 v = new Vector3(Random.Range(-100, 100), Random.Range(-50, 50), 0);
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
}
