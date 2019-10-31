
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ZoomInObject : MonoBehaviour, IInteractable
{
    public float ZoomRatio = .5f;
    public void Interact(DisplayImage currentDisplay)
    {
        Camera.main.orthographicSize *= ZoomRatio;
        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);
        Debug.Log("Zoom executado");

        currentDisplay.CurrentState = DisplayImage.State.zoom;
        gameObject.layer = 2;

        ConstrainCamera();
    }

    void ConstrainCamera()
    {
        var height = Camera.main.orthographicSize;
        var width = height * Camera.main.aspect;

        var cameraBounds = GameObject.Find("cameraBounds");

        if(Camera.main.transform.position.x + width > cameraBounds.transform.position.x + cameraBounds.GetComponent<BoxCollider2D>().size.x / 2)
        {
            Camera.main.transform.position += new Vector3(cameraBounds.transform.position.x + cameraBounds.GetComponent<BoxCollider2D>().size.x / 2 - (Camera.main.transform.position.x + width), 0, 0);
        }
        if (Camera.main.transform.position.x - width < cameraBounds.transform.position.x - cameraBounds.GetComponent<BoxCollider2D>().size.x / 2)
        {
            Camera.main.transform.position += new Vector3(cameraBounds.transform.position.x - cameraBounds.GetComponent<BoxCollider2D>().size.x / 2 - (Camera.main.transform.position.x - width), 0, 0);
        }

        if (Camera.main.transform.position.y + height > cameraBounds.transform.position.y + cameraBounds.GetComponent<BoxCollider2D>().size.y / 2)
        {
            Camera.main.transform.position += new Vector3( 0, cameraBounds.transform.position.y + cameraBounds.GetComponent<BoxCollider2D>().size.y / 2 - (Camera.main.transform.position.y + height), 0);
        }
        if (Camera.main.transform.position.y - width < cameraBounds.transform.position.y - cameraBounds.GetComponent<BoxCollider2D>().size.y / 2)
        {
            Camera.main.transform.position += new Vector3( 0, cameraBounds.transform.position.y - cameraBounds.GetComponent<BoxCollider2D>().size.y / 2 - (Camera.main.transform.position.y - height), 0);
        }
    }
}