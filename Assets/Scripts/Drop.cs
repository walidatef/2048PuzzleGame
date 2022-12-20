using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Drop : MonoBehaviour,IDropHandler
{
    [SerializeField] public  Transform[] allCells;
     

   
    public void OnDrop(PointerEventData eventData)
    {


        if (eventData.pointerDrag != null)
        {
           if (eventData.pointerDrag.GetComponent<Drag>().canDrag)
                 eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition - new Vector2(183.5f, -226.5f);
       



        }
       
         

           
        }
}
