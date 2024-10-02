using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public enum SlotState { Basic, Potion, Weapon, Shield, Power,BasicB }
    public SlotState currentState = SlotState.Basic;
    
    public bool isOccupied = false;
    //if the slot is empty and the item is of the correct tag, let the item be dropped in the slot if not return the item to its original position
    public void OnDrop(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag != null)
        {
            DragHandler dragNDrop = eventData.pointerDrag.GetComponent<DragHandler>();
            if (dragNDrop != null)
            {
                if (currentState == SlotState.Potion && dragNDrop.gameObject.tag == "Potion" && !isOccupied)
                {
                    dragNDrop.transform.SetParent(transform);
                    dragNDrop.transform.position = transform.position;
                    dragNDrop.startPosition = transform.position;
                    gameObject.GetComponent<Image>().color = new Color() { r = 1, g = 1, b = 1, a = 0 };
                    isOccupied = true;
                }
                else if (currentState == SlotState.Weapon && dragNDrop.gameObject.tag == "Weapon" && !isOccupied)
                {
                    dragNDrop.transform.SetParent(transform);
                    dragNDrop.transform.position = transform.position;
                    dragNDrop.startPosition = transform.position;
                    gameObject.GetComponent<Image>().color = new Color() { r = 1, g = 1, b = 1, a = 0 };
                    isOccupied = true;
                }
                else if (currentState == SlotState.Shield && dragNDrop.gameObject.tag == "Shield" && !isOccupied)
                {
                    dragNDrop.transform.SetParent(transform);
                    dragNDrop.transform.position = transform.position;
                    dragNDrop.startPosition = transform.position;
                    gameObject.GetComponent<Image>().color = new Color() { r = 1, g = 1, b = 1, a = 0 };
                    isOccupied = true;
                }
                else if (currentState == SlotState.Power && dragNDrop.gameObject.tag == "Power" && !isOccupied)
                {
                    dragNDrop.transform.SetParent(transform);
                    dragNDrop.transform.position = transform.position;
                    dragNDrop.startPosition = transform.position;
                    gameObject.GetComponent<Image>().color = new Color() { r = 1, g = 1, b = 1, a = 0 };
                    isOccupied = true;
                }
                else if (currentState == SlotState.Basic && !isOccupied)
                {
                    dragNDrop.transform.SetParent(transform);
                    dragNDrop.transform.position = transform.position;
                    dragNDrop.startPosition = transform.position;
                    gameObject.GetComponent<Image>().color = new Color() { r = 1, g = 1, b = 1, a = 0 };
                    isOccupied = true;
                }
                else if (currentState == SlotState.BasicB && dragNDrop.gameObject.tag == "Basic" && !isOccupied)
                {
                    dragNDrop.transform.SetParent(transform);
                    dragNDrop.transform.position = transform.position;
                    dragNDrop.startPosition = transform.position;
                    gameObject.GetComponent<Image>().color = new Color() { r = 1, g = 1, b = 1, a = 0 };
                    isOccupied = true;
                }
                else
                {
                    //return the item to the last slot it was into position
                    dragNDrop.transform.position = dragNDrop.startPosition;
                    Debug.Log(dragNDrop.startPosition);

                }
            }
        }
    }
}
