using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    //variável para capturar o display que esta sendo exibido
    private DisplayImage currentDisplay;
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }

   
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            //após o jogador clicar na tela, é preciso capturar a sua posição
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 1);
            Debug.Log("Botão pressionado"+hit);
            //em seguida, executa uma ação se o click for sobre um objeto que é possível interagir no cenário.
            if(hit && hit.transform.tag == "Interactable")
            {
                hit.transform.GetComponent<IInteractable>().Interact(currentDisplay);
                Debug.Log("Hit em um interactable");
            }
        }
    }
}
