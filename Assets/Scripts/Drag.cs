using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    private static int fillCellNum = 10;
    private bool gameOver = false;
    void Update()
    {
        if (doShiftDown)
        {
            shiftDwon();
        }
        
        if(allCell[0].childCount!=0 && allCell[1].childCount != 0 && allCell[2].childCount != 0 && allCell[3].childCount != 0 && allCell[4].childCount != 0)
        {
            gameOver = true;
            gameControllerClass.gameOverWindow.SetActive(true);
            gameControllerClass.textGameOver.text = "Your Score is " + gameControllerClass.current_score;
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
            itemPointerDown = eventData.pointerEnter.GetComponent<RectTransform>().parent.parent.name;
            GameObject thisItem = GameObject.Find(itemPointerDown);
            ShiftToUp itemClicked = thisItem.GetComponent<ShiftToUp>();
           
           if (itemClicked.up != null && itemClicked.up.childCount != 0 )
            {
                canDrag = itemClicked.up.GetChild(0).GetComponentInChildren<Text>().text == itemClicked.GetComponent<Transform>().GetChild(0).GetComponentInChildren<Text>().text;
                Debug.Log("can drag up -> " + canDrag);
               
                if (itemClicked.left != null && !canDrag ){
                    if (itemClicked.left.childCount != 0)
                    {
                        canDrag = itemClicked.left.GetChild(0).GetComponentInChildren<Text>().text == itemClicked.GetComponent<Transform>().GetChild(0).GetComponentInChildren<Text>().text;
                        Debug.Log("can drag left -> " + canDrag);
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
                        Debug.Log("can drag right -> " + canDrag);
                    }
                    else
                    {
                        canDrag = true;
                    }
                }
                if (itemClicked.down != null && !canDrag && itemClicked.down.tag != "CellDown")
                {
                    if (itemClicked.down.childCount != 0 )
                    {
                        canDrag = itemClicked.down.GetChild(0).GetComponentInChildren<Text>().text == itemClicked.GetComponent<Transform>().GetChild(0).GetComponentInChildren<Text>().text;
                        Debug.Log("can drag down -> " + canDrag);
                    }
                    else
                    {
                        canDrag = true;
                    }

                }

            }else if (itemClicked.up.childCount == 0)
            {
                canDrag = true;
                Debug.Log("can drag up -> " + canDrag);
            }
        }

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag )
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
            transform.SetParent(rectTransform.root);
            transform.SetAsLastSibling();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(canDrag )
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag )
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;    
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
                    gameControllerClass.mergeEffect.Play();
                    // NUM IN FILLCELL
                    int mergeNum = (numInDraging + numInParent);
                    if (mergeNum > PlayerPrefs.GetInt("highNumInGame"))
                    {
                        PlayerPrefs.SetInt("highNumInGame", mergeNum) ;
                    }

                    int oldScore = int.Parse(gameControllerClass.current_score_text.text);
                    int newScore = oldScore + numInDraging;
                    gameControllerClass.current_score_text.text = newScore.ToString();                
                    gameControllerClass.current_score = newScore;
                    collision.gameObject.GetComponentInChildren<Text>().text = mergeNum.ToString();
                    if (newScore  == 10000)
                    {
                        gameControllerClass.showGG();
                    }
                    //color after merge
                    collision.gameObject.GetComponentInParent<Button>().image.color = new Color(mergeNum * .03f, 0.2f, mergeNum * .04f);
                    fillCellNum--;
                    Debug.Log("items num = "+fillCellNum);
                    // shift and create new fillcells when fillCellNum == 6
                    if (fillCellNum <= 5)
                    {
                         shiftUp();
                        fillCellNum += 5;
                        object x = 5;
                        collision.gameObject.GetComponent<Transform>().parent.parent.GetComponent<FillCell>().SpwanFill(5);
                       
                    }

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
        gameControllerClass.shiftUpEffect.Play();
        for (int i = 0; i < 30; i++)
        {
            ShiftToUp parentCell = allCell[i].GetComponent<ShiftToUp>();
         
        if (parentCell.up != null && allCell[i].childCount != 0 && parentCell.up.childCount ==0)
        {
            if (!gameOver )
            {
                        allCell[i].GetChild(0).GetComponent<Transform>().position = parentCell.up.transform.position;
                        allCell[i].GetChild(0).GetComponent<RectTransform>().SetParent(parentCell.up);                        
            }
            else
            {
                        Debug.Log("Game Over");
                       // Game Over    
            }
        }
        }
        if (GetComponentInParent<FillCell>() != null)
        {
            GetComponentInParent<FillCell>().SpwanFill(5);
        }
       
       
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
