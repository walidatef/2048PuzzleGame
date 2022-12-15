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
        SpwanFill();
    }
    public void SpwanFill()
    {
        Text num;
        for (int whichSpawn=0; whichSpawn<10; whichSpawn++)
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);
            num=  tempFill.GetComponentInChildren<Text>();
            num.text = "4";
        }
        
    }
   

}
