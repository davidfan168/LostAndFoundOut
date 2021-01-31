using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private void Awake()
    {
        if (DataManager.Instance == null)
        {
            DataManager.Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Initialize();
    }

    public int day;
    public GameObject selectedItem;
    public GameObject currentStudent;
    public List<GameObject> items;
    public List<GameObject> students;

    public GameEvent startDrag;

    public void Initialize()
    {
        day = 1;
    }

    public void addItems(List<GameObject> newItems)
    {
        items = newItems;
    }

    public void setStudents(List<GameObject> students)
    {
        this.students = students;
    }
}
