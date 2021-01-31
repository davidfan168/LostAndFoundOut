using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Canvas canvas;
    private RectTransform rectTransform;
    private Image img;

    private Image displayImg;

    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        img = gameObject.GetComponent<Image>();
        img.alphaHitTestMinimumThreshold = 0.01f;
        displayImg = GameObject.FindGameObjectWithTag("DisplayImage").GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DataManager.Instance.selectedItem = gameObject;
        displayImg.sprite = img.sprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
