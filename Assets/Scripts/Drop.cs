using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Drop : MonoBehaviour,IDropHandler
{
    
    public void OnDrop(PointerEventData eventData)
    {
      
        
        Drag drag = eventData.pointerDrag.GetComponent<Drag>();
        /*  drag.parentAfterDrag = transform;*/
        if (eventData.pointerDrag != null)
        {
            /* Drag drag = eventData.pointerDrag.GetComponent<Drag>();

              drag.parentAfterDrag = transform;*/
            Debug.Log(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Debug.Log(GetComponent<RectTransform>().anchoredPosition);
            Debug.Log(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);

          
        }
    }
}