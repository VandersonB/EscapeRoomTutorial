using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    //assistir o video desde o inicio e retomar a partir 07:30



    public GameObject Inventory;
    private string displayImage;
    public enum property { usable, displayable, empty};
    public property ItemProperty { get;  set; }
    public string combinationItem { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        Inventory = GameObject.Find("Inventory");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory.GetComponent<Inventory>().previousSelectedSlot = Inventory.GetComponent<Inventory>().currentSelectedSlot;
        Inventory.GetComponent<Inventory>().currentSelectedSlot = this.gameObject;
        Combine();
        if (ItemProperty == Slot.property.displayable) DisplayItem();
    }

    public void AssignProperty(int orderNumber, string displayImage, string combinationItem)
    {
        ItemProperty = (property)orderNumber;
        this.displayImage = displayImage;
        this.combinationItem = combinationItem;
    }

  
    public void DisplayItem()
    {
        Inventory.GetComponent<Inventory>().itemDisplayer.SetActive(true);
        Inventory.GetComponent<Inventory>().itemDisplayer.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/" + displayImage);
    }

    public void Combine()
    {
        if (Inventory.GetComponent<Inventory>().previousSelectedSlot.GetComponent<Slot>().combinationItem == this.gameObject.GetComponent<Slot>().combinationItem && this.gameObject.GetComponent<Slot>().combinationItem!="")
        {
            Debug.Log("Combinar");
            GameObject combinedItem = Instantiate(Resources.Load<GameObject>("Combined Items/" + combinationItem));
            combinedItem.GetComponent<PickUpItem>().ItemPickUp();
            Inventory.GetComponent<Inventory>().previousSelectedSlot.GetComponent<Slot>().ClearSlot();
            Inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slot>().ClearSlot();
            ClearSlot();

        }
         
    }

    public void ClearSlot()
    {
        Debug.Log("limpou o slot");
        ItemProperty = Slot.property.empty;
        displayImage = "";
        combinationItem = "";
        transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");
    }
 
}
