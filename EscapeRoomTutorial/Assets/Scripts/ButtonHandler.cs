using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{

    private DisplayImage currentDisplay; 
    //quando eu criei o scrip DisplayImage, ele passou a ser uma classe pública. Sendo assim, eu posso puxar uma variável do "tipo" DisplayImage
    //o ponto é que, nesse caso, eu altero o CurrentWall, de forma que mudo a tela que será exibida.
    
    private float initialCameraSize;
    private Vector3 initialCameraPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        initialCameraPosition = Camera.main.transform.position;
        initialCameraSize = Camera.main.orthographicSize;
    }


    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;  
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
    }

    public void OnClickReturn()
    {
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {

            GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.normal;
            var zoomInObjects = FindObjectsOfType<ZoomInObject>();
            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }
            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }
        else
        {
            GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.normal;
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
        }
    
    }
}
