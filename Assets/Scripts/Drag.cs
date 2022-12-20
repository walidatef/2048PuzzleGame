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
    [HideInInspector] public Transform parentAfterDrag, parentBeforeDrag;
    private float x, y;
    [HideInInspector] public Rigidbody2D itemDraging;
    private bool isDraged = false;
    private bool shifting = false;
    public static string parentCell="";
    /* from drop file*/
    private Transform[] allCell;
    /* */
    [SerializeField] GameObject fillPrefab;
   private bool canDrag = false;
    void Update()
    {
        shiftDwon();
        // To shift up
        if (Input.GetKeyDown("space"))
        {
            shift();
        }
     
       
    }
    
    private void Awake()
    {
        allCell = GetComponentInParent<Drop>().allCells;
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>(); 
        canvasGroup = GetComponent<CanvasGroup>();
       
    }
   
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDraged = true;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        parentAfterDrag = rectTransform.parent;
        transform.SetParent(rectTransform.root);
       transform.SetAsLastSibling();
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
      
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            //rectTransform.SetParent(parentAfterDrag);
            itemDraging = gameObject.GetComponent<Rigidbody2D>();
            itemDraging.isKinematic = false;
            itemDraging.gravityScale = 20;
       
    

    }

     void OnCollisionEnter2D(Collision2D collision)
    {

        

        //CELL THAT DRAGED
        if (itemDraging != null)
        {
            if (collision.gameObject.GetComponent<Transform>().childCount != 0)
            {
                int numInParent = int.Parse(collision.gameObject.GetComponentInChildren<Text>().text);
                int numInDraging = int.Parse(this.gameObject.GetComponentInChildren<Text>().text);


                Debug.Log(collision.gameObject.GetComponent<Transform>().parent.name);

                if (numInDraging == numInParent)
                {
                    Destroy(itemDraging.gameObject);
                    float sum = (numInDraging + numInParent);
                    collision.gameObject.GetComponentInChildren<Text>().text = sum.ToString();
                    collision.gameObject.GetComponentInParent<Button>().image.color = new Color(sum * .02f, .1f, sum * .02f);
                    Debug.Log("Marged");


                }
                else
                {
                    this.gameObject.GetComponent<Transform>().SetParent(GameObject.Find(collision.gameObject.GetComponent<Transform>().parent.name).GetComponent<ShiftToUp>().up);

                    itemDraging.gravityScale = 0;
                    itemDraging.isKinematic = true;

                    Debug.Log("Not Marged and shift to up");

                }
            }
            else
            {
                /* this bottom cells*/
                this.gameObject.GetComponent<Transform>().SetParent(GameObject.Find(collision.gameObject.GetComponent<Transform>().name).GetComponent<ShiftToUp>().up);
                itemDraging.gravityScale = 0;
                itemDraging.isKinematic = true;

                Debug.Log("Not Marged and shift to up");
            }


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
                Time.timeScale = 0;
              
            }
           

        }
    }
    void shiftDwon()
    {
        
            /* shift dwon */
            for (int i = 0; i <= 24; i++)
            {
                if (allCell[i].childCount != 0 && allCell[i + 5].childCount == 0)
                {
                    allCell[i].GetChild(0).GetComponent<Transform>().position = allCell[i + 5].transform.position;
                    //  allCell[i].GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                    //  allCell[i].GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 20;
                    allCell[i].GetChild(0).GetComponent<RectTransform>().SetParent(allCell[i + 5]);
                    Debug.Log("shift dwon");

                }
            }
          
        
    }

  
}
