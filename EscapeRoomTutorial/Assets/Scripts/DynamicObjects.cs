using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicObjects : MonoBehaviour, IInteractable 
{

    public string UnlockItem;

   
    

    public enum InteractionProperty { simple_interaction, access_interaction}
    public InteractionProperty Property;

    public string unlockItem;
    public GameObject AccessObject;
    public GameObject ChangedStateSprite;

    private GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        
        ChangedStateSprite.SetActive(false);
        inventory = GameObject.Find("Inventory");
        if (Property == InteractionProperty.simple_interaction) return;
        AccessObject.SetActive(false);
    }


    public void Interact(DisplayImage currentDisplay)
    {
        string UnlockItem = unlockItem;

        if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem || UnlockItem == "")
        {
            ChangedStateSprite.SetActive(true);
            inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slot>().ClearSlot();
            this.gameObject.layer = 2;
            AccessObject.SetActive(true);

            if (Property == InteractionProperty.simple_interaction) return;
        }
    }


}
