
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManage : MonoBehaviour
{

    private DisplayImage currentDisplay;

    public GameObject [] ObjectsToManage;
    public GameObject[] UIRendererObjects;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        RenderUI();
    }

    // Update is called once per frame
    void Update()
    {
        ManageObjects();
    }

    void ManageObjects()
    {
        for(int i=0; i< ObjectsToManage.Length; i++)
        {
            if (ObjectsToManage[i].name == currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                ObjectsToManage[i].SetActive(true);
            }
            else
            {
                ObjectsToManage[i].SetActive(false);
            }
        }
    }

    void RenderUI()
    {
        for(int i=0; i<UIRendererObjects.Length; i++)
        {
            UIRendererObjects[i].SetActive(false);
        
        }
    }
}
