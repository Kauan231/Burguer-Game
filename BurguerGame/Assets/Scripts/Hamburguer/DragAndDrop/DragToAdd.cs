using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToAdd : MonoBehaviour
{
    GameObject _instance;
    Vector3 mousePosition;

    private Vector3 GetMousePosition(){
        return Camera.main.WorldToScreenPoint(_instance.transform.position);
    }
    private void OnMouseDown(){
        if(_instance == null) _instance = Instantiate(gameObject, transform.position, transform.rotation);
        mousePosition = Input.mousePosition - GetMousePosition();
    }
    private void OnMouseUp(){
        Destroy(_instance);
    }
    private void OnMouseDrag(){
        Vector3 Temp  = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, .9f));
        Temp = new Vector3(Temp.x, Mathf.Clamp(Temp.y, 1f, 1.3f), Temp.z);
        if(_instance != null) _instance.transform.position = Temp;
    }

}
