using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{ Phone, Wallet, Key, Glasses, IDCard, WaterBottle, FlashDrive}
public class Item : MonoBehaviour
{
    public ItemType item;
    public string itemName;
    public string date;
    public string location;
    public string color;
    public string type;
    public List<string> properties = new List<string>();
}

