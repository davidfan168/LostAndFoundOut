using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{ Phone, Wallet, Key, Glasses, IDCard, WaterBottle }
public class Item : MonoBehaviour
{
    public ItemType item;
    public string itemName;
    public string location;
    public string color;
    public List<string> properties = new List<string>();
}

