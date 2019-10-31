using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{


    private int currentWall;
    private int previousWall;

    public enum State
    {
        normal, zoom, changeView
    };

    public State CurrentState { get; set; }
    public int CurrentWall /*variável que irá monitorar o valor e trocar de telas*/
    {
        get { return currentWall; }
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


    // Start is called before the first frame update
    void Start()
    {
        previousWall = 0;
        currentWall = 1;
    }

    // Update faz com que, frame a frame, o GO DisplayImage atualize qual é a tela que deve ser carregada
    void Update()
    {
        if (currentWall!=previousWall)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Wall" + currentWall.ToString());
        }

        previousWall = currentWall;
    }

}

