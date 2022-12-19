using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Drop : MonoBehaviour,IDropHandler
{
    [SerializeField] public  Transform[] allCells;
   


     void Start()
    {
       
    }

    public void OnDrop(PointerEventData eventData)
    {


        if (eventData.pointerDrag != null)
        {
            Drag drag = eventData.pointerDrag.GetComponent<Drag>();
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition - new Vector2(183.5f, -226.5f);
          
           // drag.parentAfterDrag.SetParent(transform);
        }
       
            /*
            Drag drag = eventData.pointerDrag.GetComponent<Drag>()
        //    Debug.Log( allCells[0].position);
            if (eventData.pointerDrag != null)
            {
                if (allCells[0].childCount != 0)
                {

                    if (eventData.pointerDrag.GetComponentInChildren<Text>().text == allCells[0].GetComponentInChildren<Text>().text)
                    {
                        eventData.pointerDrag.GetComponent<Transform>().position = allCells[0].position;
                       // drag.parentAfterDrag = allCells[0];
                        Debug.Log("Marged");
                        // Destroy(gameObject);
                    }

                }
                else
                {
                    eventData.pointerDrag.GetComponent<Transform>().position = allCells[0].position;
                    drag.parentAfterDrag = allCells[0];
                }



                // drag.parentAfterDrag = allCells[4];
                // drag.parentAfterDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                //  eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                //Vector2 v = new Vector2(183.5f, -226.5f);
                // Debug.Log(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
                //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition - v;



            }*/
        }
}
