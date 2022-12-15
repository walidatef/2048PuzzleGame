using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    GameObject fillCell;
     void Start()
    {
        fillCell = GetComponent<GameObject>();    
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
    }


     void OnCollisionEnter(Collision collision)
    {
            Debug.Log("OnCollisionEnter2D");        
    }
     void OnTriggerEnter(Collider collision)
    {
        Debug.Log("OnTriggerEnter2D");
    }
}
