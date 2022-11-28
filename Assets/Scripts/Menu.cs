using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	

	void Update(){


	}
	public void PlayGame(){
		SceneManager.LoadScene ("Game");
	}

	public void GoToMainMenu(){
		SceneManager.LoadScene ("Menu");
	}
}
