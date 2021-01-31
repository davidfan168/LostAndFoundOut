using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionController : MonoBehaviour
{
    public Text itemName;
    public Text date;
    public Text location;
    public Text color;
    public Text type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePanel()
    {
        Item itemInfo = DataManager.Instance.selectedItem.GetComponent<Item>();
        itemName.text = "Item: " + itemInfo.itemName;
        date.text = "Date:" + itemInfo.date;
        location.text = "Location:" + itemInfo.location;
        color.text = "Color: " + color;
        type.text = "Type:" + type;
    }
}
