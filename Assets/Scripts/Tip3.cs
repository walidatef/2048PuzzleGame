using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tip3 : MonoBehaviour
{
    public GameObject prev;
    public GameObject current;

    public void backtoscene2()
    {
       current.SetActive(false);
       prev.SetActive(true);
    }
}
