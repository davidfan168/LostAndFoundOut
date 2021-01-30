using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayGenerator : MonoBehaviour
{
    List<Student> students = new List<Student>();
    List<GameObject> items = new List<GameObject>();
    public Canvas canvas;
    public GameObject bin;

    void Awake()
    {
        GenerateStudentAndItem();
        GenerateFakeItem();
        GenerateLyingStudent();
        StoreGeneratedEntities();
        InitializeStorageCabin();
    }

    private void GenerateStudentAndItem()
    {
        Student std = new Student();
        GameObject item = ItemGenerator.Instance.getRandomItem();

        items.Add(item);
    }

    private void GenerateFakeItem()
    {

    }

    private void GenerateLyingStudent()
    {

    }

    private void StoreGeneratedEntities()
    {

    }

    private void InitializeStorageCabin()
    {
        Quaternion q = Quaternion.Euler(0, 0, Random.Range(0, 360));
        Vector3 v = new Vector3(Random.Range(-100,100), Random.Range(-50,50), 0);
        GameObject obj = Instantiate(items[0], v, q);
        obj.transform.SetParent(bin.transform, false);
        obj.GetComponent<DraggableItem>().canvas = canvas;
    }
}

public class Student
{
    public Item lostItem;
    public Student()
    {
    }
}
