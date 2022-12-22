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

        PlayerPrefs.SetInt("highNumInGame", 16);
        PlayerPrefs.SetInt("lowNumInGame", 2);
        SpwanFill(10);

       
    }
    public void SpwanFill(int count)
    {
        Text num;

       Debug.Log( PlayerPrefs.GetInt("highNumInGame"));
        for (int whichCell = 0; whichCell<count; whichCell++)
        {
            float which = Random.Range(0f, 1f);
            if(allCells[allCells.Length - whichCell - 1].childCount == 0)
            {

            
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
            else if (which < 1f){

                    num.text = "16";
                    tempFill.GetComponent<Button>().image.color = new Color(16 * .03f, .2f, 16 * .04f);
            }

            }

        }
        
    }

    public void SpawnFillAtShiftUp(int count)
    {
        Text num;
        for (int whichcell = 0; whichcell < count; whichcell++)
        {
            float which = Random.Range(0f, 1f);
            if (allCells[allCells.Length - whichcell - 1].childCount == 0)
            {


                GameObject tempFill = Instantiate(fillPrefab, allCells[allCells.Length - whichcell - 1]);
                num = tempFill.GetComponentInChildren<Text>();
                int h = PlayerPrefs.GetInt("highNumInGame");
                int l = PlayerPrefs.GetInt("lowNumInGame");
                if ((h / 1024) > l)
                {
                    if (which < .1f)
                    {
                        num.text = h.ToString();
                        tempFill.GetComponent<Button>().image.color = new Color(h * .03f, .2f, 2 * .04f);
                    }
                    else if (which < .2f)
                    {
                        num.text = (h / 2).ToString();
                        tempFill.GetComponent<Button>().image.color = new Color((h / 2) * .03f, .2f, 4 * .04f);
                    }
                    else if (which < .3f)
                    {
                        num.text = (h / 4).ToString();
                        tempFill.GetComponent<Button>().image.color = new Color((h / 4) * .03f, .2f, (h / 4) * .04f);
                    }
                    else if (which < .4f)
                    {
                        num.text = (h / 8).ToString();
                        tempFill.GetComponent<Button>().image.color = new Color((h / 8) * .03f, .2f, (h / 8) * .04f);
                    }
                    else if (which < .5f)
                    {
                        num.text = (h / 16).ToString();
                        tempFill.GetComponent<Button>().image.color = new Color((h / 16) * .03f, .2f, (h / 16) * .04f);
                    }
                    else if (which < .6f)
                    {
                        num.text = (h / 32).ToString();
                        tempFill.GetComponent<Button>().image.color = new Color((h / 32) * .03f, .2f, (h / 32) * .04f);
                    }
                    else if (which < .7f)
                    {
                        num.text = (h / 64).ToString();
                        tempFill.GetComponent<Button>().image.color = new Color((h / 64) * .03f, .2f, (h / 64) * .04f);
                    }
                    else if (which < .8f)
                    {
                        num.text = (h / 128).ToString();
                        tempFill.GetComponent<Button>().image.color = new Color((h / 128) * .03f, .2f, (h / 128) * .04f);
                    }
                    else if (which < .9f)
                    {
                        num.text = (h / 256).ToString();
                        tempFill.GetComponent<Button>().image.color = new Color((h / 256) * .03f, .2f, (h / 256) * .04f);
                    }
                    else if (which < 1f)
                    {
                        num.text = (h / 512).ToString();
                        tempFill.GetComponent<Button>().image.color = new Color((h / 512) * .03f, .2f, (h / 512) * .04f);
                    }
                }
                else
                {
                    int range = h / l;
                    float c = Mathf.Log(range, 2);

                    int x = (int)c;
                    x += 1;
                    float cc = x;

                    float which1 = Random.Range(0f, cc / 10);
                    for (float i = 1; i <= x; i++)
                    {
                        if (which1 < (i / 10))
                        {

                            int z = (int)(Mathf.Pow(2, i));

                            Debug.Log(z);
                            num.text = z.ToString();

                            tempFill.GetComponent<Button>().image.color = new Color(z * .03f, .2f, z * .04f);
                            break;
                        }
                    }






                }
            }
        }
    }

}
