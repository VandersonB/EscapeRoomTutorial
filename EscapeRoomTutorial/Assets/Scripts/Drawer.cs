using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour, IInteractable  
{

    public string UnlockItem;
    private GameObject inventory;
    private GameObject drawer;

    void Start()
    {
        inventory = GameObject.Find("Inventory");
        drawer = GameObject.Find("drawer1");
        drawer.SetActive(false);
    }
    public void Interact(DisplayImage currentDisplay)
    {
        if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            //Debug.Log("Abriu a gaveta");
            //  inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slot>().ItemProperty = Slot.property.empty;
            //  inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");

            inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slot>().ClearSlot();
            drawer.SetActive(true);
        }
    }


}
