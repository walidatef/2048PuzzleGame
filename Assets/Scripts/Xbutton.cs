using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbutton : MonoBehaviour
{
    public GameObject tip1;
    public GameObject tip2;
    public GameObject tip3;
    public void exit()
    {
        tip1.SetActive(false); 
        tip2.SetActive(false); 
        tip3.SetActive(false);    
    }
    
}
