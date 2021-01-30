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

    public void Initialize()
    {
        day = 1;
    }
}
