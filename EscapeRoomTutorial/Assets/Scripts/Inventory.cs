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
        HideDisplay();
    }



    void InitializeInventory()
    {
        slots = GameObject.Find("slots");
        itemDisplayer = GameObject.Find("ItemDisplayer");
        itemDisplayer.SetActive(false);
        foreach (Transform slot in slots.transform)
        {
            slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");
            slot.GetComponent<Slot>().ItemProperty = Slot.property.empty;
        }

        currentSelectedSlot = GameObject.Find("slot");
        previousSelectedSlot = currentSelectedSlot;
    }


    public void SelectSlot()
    {
      
        foreach(Transform slot in slots.transform)
        {
            if(slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.usable)
            {
                slot.GetComponent<Image>().color = new Color(0.9f, 0.4f, 0.6f, 1);
               
            }
            else if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
            {
                //slot.GetComponent<Slot>().DisplayItem();  EXISTE UM PROBLEMA NESSA LINHA DE CÓDIGO, QUANDO EU CHAMAVA DOIS ITENS "DISPLAYABLE" FICAVA TRAVADO, BUSCAR ENTENDER MELHOR DURANTE A DISCVUSSÃO DO PROJETO
            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }

        }
    }

    void HideDisplay()
    {
        if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            itemDisplayer.SetActive(false);
         
            foreach(Transform slot in slots.transform)
            {
                if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
                {
                    currentSelectedSlot = previousSelectedSlot;
                    previousSelectedSlot = currentSelectedSlot;
                }
            }
           
        }
    }
}
