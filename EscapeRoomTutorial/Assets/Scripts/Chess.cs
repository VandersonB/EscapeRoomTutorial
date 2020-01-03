using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Chess : MonoBehaviour, IPointerClickHandler
{

    public GameObject ScreenPanel;
    public GameObject ObtainItem;
    private GameObject displayImage;

    public string CorrectPassword;
    private string inputPassword;

    private bool isCorrectPassword=false;
    void Start()
    {
        displayImage = GameObject.Find("displayImage");
        ObtainItem.SetActive(false);
        this.gameObject.SetActive(false); 
    }

    void Update()
    {
        VerifyPassword();
        HideDisplay();
    }

    void VerifyPassword()
    {
        if (isCorrectPassword) return;
        
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            inputPassword = ScreenPanel.transform.Find("Text").GetComponent<Text>().text;
            ScreenPanel.transform.Find("Text").GetComponent<Text>().text = "";

            if (inputPassword == CorrectPassword)
            {
                Destroy(GameObject.Find("ScreenActivator"));
                Destroy(ScreenPanel);
                isCorrectPassword = true;
                //Debug.Log("Password Correct");
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/chess_solved");
                ObtainItem.SetActive(true);
            }
        }
    
    }


    void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
        }

        if(displayImage.GetComponent<DisplayImage>().CurrentState== DisplayImage.State.normal)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ScreenPanel.SetActive(false);

    }
}
