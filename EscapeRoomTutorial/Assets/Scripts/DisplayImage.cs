using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    /*variável que irá monitorar o valor e trocar de telas*/
    public int CurrentWall 
    {
        get { return CurrentWall; }
        set    
        {
            if(value == 5)
            
                currentWall = 1;
            
                else if (value == 0)
            
                currentWall = 4;
            
                else
                currentWall = value;
        } 
    }

    private int currentWall;
    private int previousWall;

    // Start is called before the first frame update
    void Start()
    {
        previousWall = 0;
        currentWall = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Wall" + currentWall.ToString());
    }

}

