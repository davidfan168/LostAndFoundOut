using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public static ItemGenerator Instance;
    private void Awake()
    {
        if (ItemGenerator.Instance == null)
        {
            ItemGenerator.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject[] items;
    private DateTime startDate = new DateTime(2020, 02, 01);
    private string[] locations = new string[] { "Classroom", "Residence hall", "Library", "Parking lot", "Bathroom" };

    public GameObject getRandomItem()
    {
        int index = UnityEngine.Random.Range(0, items.Length);
        GameObject item = Instantiate(items[index]);

        InitializeItem(item);

        return item;
    }

    public GameObject getRandomItemEasy()
    {
        int index = UnityEngine.Random.Range(0, 28);
        GameObject item = Instantiate(items[index]);

        InitializeItem(item);

        return item;
    }

    public GameObject getRandomKey()
    {
        int index = UnityEngine.Random.Range(14, 20);
        GameObject item = Instantiate(items[index]);

        InitializeItem(item);

        return item;
    }

    public GameObject getRandomGlasses()
    {
        int index = UnityEngine.Random.Range(5, 14);
        GameObject item = Instantiate(items[index]);

        InitializeItem(item);

        return item;
    }

    public GameObject getRandomWaterBottle()
    {
        int index = UnityEngine.Random.Range(22, 28);
        GameObject item = Instantiate(items[index]);

        InitializeItem(item);

        return item;
    }

    private void InitializeItem(GameObject item)
    {
        int index = UnityEngine.Random.Range(0, locations.Length);
        item.GetComponent<Item>().location = locations[index];

        item.GetComponent<Item>().date = startDate.AddDays(UnityEngine.Random.Range(0, 7)).ToString("yyyy-MM-dd");
    }

}
