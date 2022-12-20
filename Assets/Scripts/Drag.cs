using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerDownHandler
{
    private RectTransform rectTransform;
    [HideInInspector] public  Canvas canvas;
    private CanvasGroup canvasGroup;
    [HideInInspector] public Transform  parentBeforeDrag;    
    [HideInInspector] public Rigidbody2D itemDraging;    
    /* from drop file*/
    private Transform[] allCell;
    /* */
    [SerializeField] GameObject fillPrefab;
    [HideInInspector] public bool canDrag = true;
    private bool doShiftDown = false;
    private string itemPointerDown;
    GameController gameControllerClass;
   
    void Update()
    {
        if (doShiftDown)
        {
            shiftDwon();
        }
        
    }
    
    private void Awake()
    {
        gameControllerClass = GameObject.Find("GameController").GetComponent<GameController>();
        allCell = GetComponentInParent<Drop>().allCells;
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>(); 
        canvasGroup = GetComponent<CanvasGroup>();
        
    }
    private void Start()
    {
      
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        /*CHECK IS DRAG OR NOT */
        if (eventData != null)
        {
            itemPointerDown = eventData.pointerEnter.GetComponentInParent<RectTransform>().parent.parent.name;
            GameObject thisItem = GameObject.Find(itemPointerDown);
            ShiftToUp itemClicked = thisItem.GetComponent<ShiftToUp>();
           
           if (itemClicked.up != null && itemClicked.up.childCount != 0 )
            {
                canDrag = itemClicked.up.GetChild(0).GetComponentInChildren<Text>().text == itemClicked.GetComponent<Transform>().GetChild(0).GetComponentInChildren<Text>().text;
                Debug.Log("can drag up" + canDrag);
               
                if (itemClicked.left != null && !canDrag ){
                    if (itemClicked.left.childCount != 0)
                    {
                        canDrag = itemClicked.left.GetChild(0).GetComponentInChildren<Text>().text == itemClicked.GetComponent<Transform>().GetChild(0).GetComponentInChildren<Text>().text;
                        Debug.Log("can drag left" + canDrag);
                    }
                    else
                    {
                        canDrag = true;
                    }
                }
                if(itemClicked.right != null && !canDrag ){
                    if (itemClicked.right.childCount != 0)
                    {

                        canDrag = itemClicked.right.GetChild(0).GetComponentInChildren<Text>().text == itemClicked.GetComponent<Transform>().GetChild(0).GetComponentInChildren<Text>().text;
                        Debug.Log("can drag right" + canDrag);
                    }
                    else
                    {
                        canDrag = true;
                    }
                }

            }
        }

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
            transform.SetParent(rectTransform.root);
            transform.SetAsLastSibling();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(canDrag)
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            //rectTransform.SetParent(parentAfterDrag);
            itemDraging = gameObject.GetComponent<Rigidbody2D>();
            itemDraging.isKinematic = false;
            itemDraging.gravityScale = 20;
            doShiftDown = true;
        }
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


               

                if (numInDraging == numInParent)
                {
                    Destroy(itemDraging.gameObject);

                    int sum = (numInDraging + numInParent);
                    if (sum > PlayerPrefs.GetInt("highNumInGame"))
                    {
                        PlayerPrefs.SetInt("highNumInGame", sum) ;
                    }
                    int currentScore = int.Parse(gameControllerClass.current_score_text.text);
                    
                    gameControllerClass.current_score_text.text = (currentScore + numInDraging).ToString();                
                    gameControllerClass.current_score = int.Parse(gameControllerClass.current_score_text.text);


                    collision.gameObject.GetComponentInChildren<Text>().text = sum.ToString();
                    collision.gameObject.GetComponentInParent<Button>().image.color = new Color(sum * .02f, .1f, sum * .02f);
                    Debug.Log("Marged");
                   

                }
                else
                {
                    this.gameObject.GetComponent<Transform>().SetParent(GameObject.Find(collision.gameObject.GetComponent<Transform>().parent.name).GetComponent<ShiftToUp>().up);
                    itemDraging.gravityScale = 0;
                    itemDraging.isKinematic = true;
                   
                    shiftUp();
                    Debug.Log("Not Marged and shift to up");

                }
            }
            else
            {
                /* this bottom cells*/
                this.gameObject.GetComponent<Transform>().SetParent(GameObject.Find(collision.gameObject.GetComponent<Transform>().name).GetComponent<ShiftToUp>().up);
                itemDraging.gravityScale = 0;
                itemDraging.isKinematic = true;
               
                shiftUp();
                
                Debug.Log("Not Marged and shift to up");
            }
            

        }

      





    }
  
    void shiftUp()
    {
        for (int i = 0; i < 30; i++)
        {
            ShiftToUp parentCell = allCell[i].GetComponent<ShiftToUp>();
        if (parentCell.up != null && allCell[i].childCount != 0)
        {
            if (parentCell.up.tag != "LossCells")
            {
                        allCell[i].GetChild(0).GetComponent<Transform>().position = parentCell.up.transform.position;
                        allCell[i].GetChild(0).GetComponent<RectTransform>().SetParent(parentCell.up);                        
            }
            else
            {
                        allCell[i].GetChild(0).GetComponent<Transform>().position = parentCell.up.transform.position;
                        allCell[i].GetChild(0).GetComponent<RectTransform>().SetParent(parentCell.up);
                        Debug.Log("Game Over");
                        // Time.timeScale = 0;
            }
        }
        }
        GetComponentInParent<FillCell>().SpwanFill(5);
        Debug.Log("shift Up");
    }
    void shiftDwon()
    {    
            /* shift dwon */
            for (int i = 0; i <= 24; i++)
            {
                if (allCell[i].childCount != 0 && allCell[i + 5].childCount == 0)
                {
                    allCell[i].GetChild(0).GetComponent<Transform>().position = allCell[i + 5].transform.position;               
                    allCell[i].GetChild(0).GetComponent<RectTransform>().SetParent(allCell[i + 5]);                  
                }
            }
    }

   
}
