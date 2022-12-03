using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tip1 : MonoBehaviour
{
    public GameObject next;
    public GameObject prev;
    public GameObject current;
    public void movetoscene2()
    {
        current.SetActive(false);
        next.SetActive(true);
    }
    

}
