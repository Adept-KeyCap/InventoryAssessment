using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public enum SlotState { General, Potion, Weapon, Shield, Power }
    public SlotState currentState = SlotState.General;
    
    public bool inUse = false;
    //if the slot is empty and the item is of the correct tag, let the item be dropped in the slot if not return the item to its original position
    public void OnDrop(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag != null)
        {
            ItemLogic dragNDrop = eventData.pointerDrag.GetComponent<ItemLogic>();
            if (dragNDrop != null)
            {
                if (currentState == SlotState.Potion && dragNDrop.gameObject.tag == "Potion" && !inUse)
                {
                    dragNDrop.transform.SetParent(transform);
                    dragNDrop.currentSlot = this;
                    dragNDrop.transform.position = transform.position;
                    dragNDrop.startPosition = transform.position;
                    inUse = true;
                }
                else if (currentState == SlotState.Weapon && dragNDrop.gameObject.tag == "Weapon" && !inUse)
                {
                    dragNDrop.transform.SetParent(transform);
                    dragNDrop.currentSlot = this;
                    dragNDrop.transform.position = transform.position;
                    dragNDrop.startPosition = transform.position;
                    inUse = true;
                }
                else if (currentState == SlotState.Shield && dragNDrop.gameObject.tag == "Shield" && !inUse)
                {
                    dragNDrop.transform.SetParent(transform);
                    dragNDrop.currentSlot = this;
                    dragNDrop.transform.position = transform.position;
                    dragNDrop.startPosition = transform.position;
                    inUse = true;
                }
                else if (currentState == SlotState.Power && dragNDrop.gameObject.tag == "Power" && !inUse)
                {
                    dragNDrop.transform.SetParent(transform);
                    dragNDrop.currentSlot = this;
                    dragNDrop.transform.position = transform.position;
                    dragNDrop.startPosition = transform.position;
                    inUse = true;
                }
                else if (currentState == SlotState.General && !inUse)
                {
                    dragNDrop.transform.SetParent(transform);
                    dragNDrop.currentSlot = this;
                    dragNDrop.transform.position = transform.position;
                    dragNDrop.startPosition = transform.position;
                    inUse = true;
                }
                else if(!inUse && dragNDrop.gameObject.tag != currentState.ToString())
                {
                    //return the item to the last slot it was into position
                    dragNDrop.currentSlot = null;
                    dragNDrop.transform.position = Vector3.zero;
                    Debug.Log(dragNDrop.startPosition);

                }
                else
                {
                    //return the item to the last slot it was into position
                    dragNDrop.currentSlot = null;
                    dragNDrop.transform.position = Vector3.zero;
                    Debug.Log(dragNDrop.startPosition);
                }
            }
        }
    }
}
