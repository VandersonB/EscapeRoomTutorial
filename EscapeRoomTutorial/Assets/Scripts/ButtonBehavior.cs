using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    
    public enum ButtonId
    {
        roomChangeButton, returnButton
    }

    public ButtonId thisButton;

    private DisplayImage currentDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

    // Update is called once per frame
    void Update()
    {
        HideDisplay();
        Display();
    }

    void HideDisplay()
    {
        if(currentDisplay.CurrentState == DisplayImage.State.normal && thisButton == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }

        if (!(currentDisplay.CurrentState == DisplayImage.State.normal) && thisButton == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }
    }

    void Display()
    {
        if (!(currentDisplay.CurrentState == DisplayImage.State.normal) && thisButton == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
         
        }

        if (currentDisplay.CurrentState == DisplayImage.State.normal && thisButton == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
            
        }
    }
}
