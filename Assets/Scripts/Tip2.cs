using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tip2 : MonoBehaviour
{
    public GameObject next;
    public GameObject prev;
    public GameObject current;

    public void movetoscene3()
    {
       current.SetActive(false);
       next.SetActive(true);
    }
    public void backtoscene1()
    {
        current.SetActive(false);
        prev.SetActive(true);
    }
}
