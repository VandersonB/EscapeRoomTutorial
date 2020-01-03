using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Blocks : MonoBehaviour, IDragHandler, IDropHandler
{
    public int correctBoxIndex;
    public int indexOfBox { get; private set; }

    private Vector3 initializePosition;
    void Start()
    {
        indexOfBox = -1;
        initializePosition = transform.position;
       //this.gameObject.SetActive(false);
       //esse trecho esta dando conflito com o bloc de número 8 e, analisando o código "scale", não há uma necessidade clara, já que 
       //os GO's dos blocos só ficam ativos quando carrega a tela Scale
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (GameObject.Find("Scale").GetComponent<Scale>().isSolved) return;

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var scale= GameObject.Find("Scale");
        bool dopredInsideOfBox = false;


        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for (int i = 0; i < scale.GetComponent<Scale>().ScaleBoxes.Length; i++)
        {

            if (mousePosition.x <= (scale.GetComponent<Scale>().ScaleBoxes[i].transform.position.x +
                scale.GetComponent<Scale>().ScaleBoxes[i].GetComponent<BoxCollider2D>().size.x / 2) &&
                mousePosition.x >= (scale.GetComponent<Scale>().ScaleBoxes[i].transform.position.x -
                scale.GetComponent<Scale>().ScaleBoxes[i].GetComponent<BoxCollider2D>().size.x / 2) &&
                mousePosition.y <= (scale.GetComponent<Scale>().ScaleBoxes[i].transform.position.y +
                scale.GetComponent<Scale>().ScaleBoxes[i].GetComponent<BoxCollider2D>().size.y / 2) &&
                mousePosition.y >= (scale.GetComponent<Scale>().ScaleBoxes[i].transform.position.y -
                scale.GetComponent<Scale>().ScaleBoxes[i].GetComponent<BoxCollider2D>().size.y / 2))
            {
                //Debug.Log(scale.GetComponent<Scale>().ScaleBoxes[i]);
                transform.position = new Vector3(scale.GetComponent<Scale>().ScaleBoxes[i].transform.position.x, scale.GetComponent<Scale>().ScaleBoxes[i].transform.position.y,
                    scale.GetComponent<Scale>().ScaleBoxes[i].transform.position.z);

                indexOfBox = i;
                dopredInsideOfBox = true;

            }

            if (!dopredInsideOfBox)
            {
                transform.position = initializePosition;
            }
        }
    }
}
