using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToRemove : MonoBehaviour
{
    Vector3 mousePosition;

    private Vector3 GetMousePosition(){
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown(){
        mousePosition = Input.mousePosition - GetMousePosition();
    }
    private void OnMouseUp(){
        Destroy(gameObject);
    }
    private void OnMouseDrag(){
        Vector3 Temp  = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, .9f));
        Temp = new Vector3(Temp.x, Mathf.Clamp(Temp.y, 1f, 1.3f), Temp.z);
        transform.position = Temp;
    }

}
