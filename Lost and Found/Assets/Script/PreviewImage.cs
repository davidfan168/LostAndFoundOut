using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewImage : MonoBehaviour
{
    public Sprite emptySprite;

    public void OnLeave()
    {
        gameObject.GetComponent<Image>().sprite = emptySprite;
    }
}
