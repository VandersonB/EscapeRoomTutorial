using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }
    public GameObject itemDisplayer { get; private set; }

    private GameObject slots;
    void Start()
    {
        
        InitializeInventory();
      
    }

     void Update()
    {
        SelectSlot();
    }



    void InitializeInventory()
    {
        slots = GameObject.Find("slots");
        itemDisplayer = GameObject.Find("ItemDisplayer");
        itemDisplayer.SetActive(false);
        foreach (Transform slot in slots.transform)
        {
            slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");
        }
    }


    public void SelectSlot()
    {
        Debug.Log("Entrou");
        foreach(Transform slot in slots.transform)
        {
            if(slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.usable)
            {
                slot.GetComponent<Image>().color = new Color(0.9f, 0.4f, 0.6f, 1);
                Debug.Log("destaque de cor");
            }
            else if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
            {

            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }

        }
    }
}
