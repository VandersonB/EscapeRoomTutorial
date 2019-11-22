using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpItem : MonoBehaviour, IInteractable
{

    private GameObject InventorySlots;
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
        InventorySlots = GameObject.Find("slots");
    }
    void ItemPickUp()
    {
        foreach(Transform slot in InventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/"+DisplaySprite);
                Debug.Log("objeto clicado");
                slot.GetComponent<Slot>().AssignProperty((int)itemProperty, DisplayImage);
                Destroy(this.gameObject);
                break;
            }
            
        }
    }
}
