using System.Collections;
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
    public GameObject getRandomItem()
    {
        int index = Random.Range(0, items.Length);
        GameObject item = Instantiate(items[index]);

        return item;
    }

}
