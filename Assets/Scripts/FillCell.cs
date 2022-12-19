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
        SpwanFill(10);
    }
    public void SpwanFill(int count)
    {
        Text num;
    

        for (int whichSpawn=0; whichSpawn<count; whichSpawn++)
        {
            float which = Random.Range(0f, 1f);
            GameObject tempFill = Instantiate(fillPrefab, allCells[allCells.Length - whichSpawn-1]);
            num = tempFill.GetComponentInChildren<Text>();
            if (which < .3f)
            {
                num.text = "2";
                tempFill.GetComponent<Button>().image.color = new Color(1,.1f,.2f);
            }
            else if (which < .6f)
            {
                num.text = "4";
                tempFill.GetComponent<Button>().image.color  = new Color(1, .1f, .4f);
            }
            else if(which < 1f){
                num.text = "8";
                tempFill.GetComponent<Button>().image.color = new Color(1, .1f, .6f);
            }



        }
        
    }
   

}
