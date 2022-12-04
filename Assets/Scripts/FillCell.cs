using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillCell : MonoBehaviour
{
    int value;
   public Text text_value;

    public void fillCell(int _value)
    {
        value = -_value;
        text_value.text = value.ToString();
    }
}
