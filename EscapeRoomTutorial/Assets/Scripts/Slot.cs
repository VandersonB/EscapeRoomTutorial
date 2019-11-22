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
    public enum property { usable, displayable};
    public property ItemProperty { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        Inventory = GameObject.Find("Inventory");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory.GetComponent<Inventory>().previousSelectedSlot = Inventory.GetComponent<Inventory>().currentSelectedSlot;
        Inventory.GetComponent<Inventory>().currentSelectedSlot = this.gameObject;
    }

    public void AssignProperty(int orderNumber, string displayImage)
    {
        ItemProperty = (property)orderNumber;
        this.displayImage = displayImage;
    }
  
    public void DisplayItem()
    {
        Inventory.GetComponent<Inventory>().itemDisplayer.SetActive(true);
        Inventory.GetComponent<Inventory>().itemDisplayer.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/" + displayImage);
    }
 
}
