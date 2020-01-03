using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public GameObject[] ScaleBoxes;
    private GameObject displayImage;
    private Blocks[] blocks;

    public GameObject scaleDisplayer;
    public bool isSolved { get; private set; }

    public int[] Weight = new int[5];

    void Awake()
    {

        isSolved = false;
        displayImage = GameObject.Find("displayImage");
        blocks = FindObjectsOfType<Blocks>();
    }

    void Update()
    {
        Display();
        if (VerifySolution()&& !isSolved)
        {
            isSolved = true;
            scaleDisplayer.GetComponent<ChangeView>().spriteName = "scale solved";
            displayImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/scale solved");
        }
    }

    void Display()
    {
        if (displayImage.GetComponent<SpriteRenderer>().sprite.name == "scale" || displayImage.GetComponent<SpriteRenderer>().sprite.name == "scale solved")
        {
           
            for (int i=0; i < blocks.Length; i++)
            {
                blocks[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < blocks.Length; i++)
            {
            blocks[i].gameObject.SetActive(false);
            }
        }
        
    }

    bool VerifySolution()
    {
        bool solved = true;
        for(int i=0; i < ScaleBoxes.Length; i++)
        {
            if (blocks[i].indexOfBox != blocks[i].correctBoxIndex)
            {
                solved = false;
             
            }
        }
        return solved;
    }

}
