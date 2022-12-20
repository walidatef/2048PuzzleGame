using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillCell : MonoBehaviour
{
   
    //fill prefab
    [SerializeField] GameObject fillPrefab;
    [SerializeField] Transform[] allCells;
   


     void Start()
    {
        PlayerPrefs.SetInt("highNumInGame", 2);
        SpwanFill(10);

       
    }
    public void SpwanFill(int count)
    {
        Text num;

       Debug.Log( PlayerPrefs.GetInt("highNumInGame"));
        for (int whichCell = 0; whichCell<count; whichCell++)
        {
            float which = Random.Range(0f, 1f);
            GameObject tempFill = Instantiate(fillPrefab, allCells[allCells.Length - whichCell-1]);
            num = tempFill.GetComponentInChildren<Text>();
            if (which < .3f)
            {
                num.text = "2";
                tempFill.GetComponent<Button>().image.color = new Color(2 * .03f, .2f, 2 * .04f);
            }
            else if (which < .6f)
            {
                num.text = "4";
                tempFill.GetComponent<Button>().image.color  = new Color(4*.03f, .2f, 4 * .04f);
            }
            else if(which < .8f){
                num.text = "8";
                tempFill.GetComponent<Button>().image.color = new Color(8 * .03f, .2f, 8 * .04f);
            }
            else if (which < 1f) {
                int h = PlayerPrefs.GetInt("highNumInGame");
                num.text = h.ToString();

                tempFill.GetComponent<Button>().image.color = new Color(h* .03f, .2f, h * .04f);
            }



        }
        
    }
   

}
