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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<GameObject> items;
    public GameObject getRandomItem()
    {
        int index = Random.Range(0, items.Count);
        GameObject item = items[index];

        return item;
    }

}
