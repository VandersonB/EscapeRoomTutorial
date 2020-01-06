using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpItem : MonoBehaviour, IInteractable
{

    private GameObject InventorySlots;
    public string CombinationItem;
    public string DisplaySprite;
    public string DisplayImage;
    public enum property { usable, displayable};
    public property itemProperty;
    public void Interact(DisplayImage currentDisplay)
    {
        ItemPickUp();
    }


    void Start()
    {
        
    }
    public void ItemPickUp()
    {

        InventorySlots = GameObject.Find("slots");
        foreach (Transform slot in InventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/"+DisplaySprite);
               
                slot.GetComponent<Slot>().AssignProperty((int)itemProperty, DisplayImage, CombinationItem);
                Destroy(this.gameObject);
                break;
            }
            
        }
    }
}
