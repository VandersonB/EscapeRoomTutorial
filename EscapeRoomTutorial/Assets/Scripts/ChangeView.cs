using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour, IInteractable

{
    private float initialCameraSize;
    private Vector3 initialCameraPosition;
    public string spriteName;

    public void Awake()
    {
        initialCameraPosition = Camera.main.transform.position;
        //GameObject.Find("Main Camera").GetComponent<Transform>().position;
        // funciona da mesma forma. Na verdade, o problema esta em usar o Start, pois não uma 
        initialCameraSize = Camera.main.orthographicSize;
        //GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize;
        //
    }
    public void Interact(DisplayImage currentDisplay)
    {
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + spriteName);
        currentDisplay.CurrentState = DisplayImage.State.changeView;

        Camera.main.orthographicSize = initialCameraSize;
        Camera.main.transform.position = initialCameraPosition;
        Debug.Log("Resetou a camera");
    }
}

   
