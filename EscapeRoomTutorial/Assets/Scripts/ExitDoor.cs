using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour, IInteractable
{
    public string UnlockItem;
    public string unlockItem;
    public GameObject ChangedStateSprite;
    private GameObject inventory;
    public GameObject EscapeMessage;

    // Start is called before the first frame update
    void Start()
    {
        ChangedStateSprite.SetActive(false);
        inventory = GameObject.Find("Inventory");
    }


    public void Interact(DisplayImage currentDisplay)
    {
        string UnlockItem = unlockItem;

        if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem || UnlockItem == "")
        {
            ChangedStateSprite.SetActive(true);
            inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slot>().ClearSlot();
            this.gameObject.layer = 2;
            Instantiate(EscapeMessage, GameObject.Find("Canvas").transform);

            StartCoroutine(LoadMenu());
        }
    }

    public IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("menu");
    }

}
