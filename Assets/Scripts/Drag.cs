using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   private RectTransform rectTransform;
    [HideInInspector] public  Canvas canvas;
    private CanvasGroup canvasGroup;
    [HideInInspector] public Transform parentAfterDrag;
    private float x, y;
   
 

    [SerializeField] GameObject fillPrefab;

    void Update()
    {
        // To shift up
        if (Input.GetKeyDown("space"))
        {
            shift();
           

        }
    }
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
      
        
        parentAfterDrag = rectTransform.parent;
        transform.SetParent(rectTransform.root);
        transform.SetAsLastSibling();
      
        
    }

    public void OnDrag(PointerEventData eventData)
    {

         rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor ;
      
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        //rectTransform.SetParent(parentAfterDrag);
       
        
      
        Rigidbody2D itemDraging = gameObject.GetComponent<Rigidbody2D>();
        itemDraging.isKinematic = false;
        itemDraging.GetComponent<Rigidbody2D>().gravityScale=20;

    }

     void OnCollisionEnter2D(Collision2D collision)
    {
       

        int numInParent =int.Parse(collision.gameObject.GetComponentInChildren<Text>().text);
        int numInDraging =int.Parse(this.gameObject.GetComponentInChildren<Text>().text);
      
        if (numInDraging == numInParent)
        {
            //  Destroy(this.gameObject);
            Debug.Log("Marged");
        }
        else
        {
            Debug.Log("Not Marged");
        }
    
    }

    void shift()
    {
        ShiftToUp parentCell = GetComponentInParent<ShiftToUp>();
        if (parentCell.up != null)
        {
            if(parentCell.up.tag != "LossCells")
            {
                transform.position = parentCell.up.position;
                transform.SetParent( parentCell.up);

               // GetComponentInParent<FillCell>().SpwanFill(5);
            }
            else
            {
                transform.position = parentCell.up.position;
                transform.SetParent(parentCell.up);
                Debug.Log("Game Over");
            }
           

        }
    }
  

}
