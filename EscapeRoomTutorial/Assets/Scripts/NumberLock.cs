using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberLock : MonoBehaviour
{

    
    public string Password;
    public GameObject openLockSprite;
    private GameObject displayImage;

    [HideInInspector]
    public Sprite[] numberSprites;
    [HideInInspector]
    public int[] currentIndividualIndex = { 0, 0, 0, 0 };
    private bool isOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        displayImage = GameObject.Find("displayImage");
        openLockSprite.SetActive(false);
        isOpen = false;
        LoadAllNumberSprites();
    }

    void Update()
    {
        OpenLocker();
        LayerManager();
    }

    void LoadAllNumberSprites()
    {
        numberSprites = Resources.LoadAll<Sprite>("Sprites/numbers");
    }
   
    bool VerifyCorrectCode()
    {
        bool correct=true;

        for(int i=0; i< 4; i++)
        {
            if (Password[i] != transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Substring(transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Length - 1)[0])
            {
                correct = false;
                
            }

        }
        return correct;
    }

    void OpenLocker()
    {
        if (isOpen) return;

        if (VerifyCorrectCode())
        {
            isOpen = true;
            openLockSprite.SetActive(true);
            Debug.Log("Gaveta aberta");

            for(int i=0; i<4; i++)
            
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

    }

    void LayerManager()
    {
        if (isOpen) return;

        if(displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.normal)
        {
            foreach(Transform child in transform)
            {
                //Debug.Log("Mudou o Sprite");
                child.gameObject.layer = 2;
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.layer = 0;
                //Debug.Log("não Mudou o Sprite");
            }
        }
    }
}
