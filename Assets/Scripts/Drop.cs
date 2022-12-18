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


            Vector2 v =new Vector2(183.5f,-226.5f);
            Debug.Log(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
            eventData.pointerDrag.GetComponentInParent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition - v ;
         // eventData.pointerDrag.GetComponent<RectTransform>();






        }
    }
}
