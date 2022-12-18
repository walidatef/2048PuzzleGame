using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   private RectTransform rectTransform;
    [HideInInspector] public  Canvas canvas;
    private CanvasGroup canvasGroup;
    [HideInInspector] public Transform parentAfterDrag;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
          canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
       canvasGroup.blocksRaycasts = false;
       parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor ;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    transform.SetParent(parentAfterDrag);
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Debug.Log("OnTriggerEnter2D");
    }

    
}
