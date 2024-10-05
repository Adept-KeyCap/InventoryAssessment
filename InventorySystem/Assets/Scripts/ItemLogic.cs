using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ItemLogic : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Vector3 startPosition;
    public TextMeshProUGUI description;
    public float value = 10;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        description = GameObject.Find("Info").GetComponent<TextMeshProUGUI>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        //if the item is dragged out of the slot, set the slot to empty
        if (transform.parent != null)
        {
            transform.parent.GetComponent<InventorySlot>().inUse = false;
            transform.parent.GetComponent<Image>().color = new Color() { r = 1, g = 1, b = 1, a = 0.09f };
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ShowDescription();
    }
    //when the item is deselected (by Selectable UI) the description is set to empty
    public void OnPointerUp(PointerEventData eventData)
    {
        description.text = "";
    }
    
    //when the item is selected (by Selectable UI) ShowDescription is called
    public void ShowDescription()
    {
        string tag = gameObject.tag;
        switch (tag)
        {
            case "Potion":
                description.text = "Potion: Heals +"+value+" HP";
                break;
            case "Weapon":
                description.text = "Weapon: +"+value+" Attack";
                break;
            case "Shield":
                description.text = "Shield: +"+value+" Defense";
                break;
            case "Power":
                description.text = "Power: +"+value+" Power";
                break;
            case "Basic":
                description.text = "Basic: No special effects";
                break;
            case "BasicB":
                description.text = "BasicB: No special effects";
                break;
        }
    }
}

