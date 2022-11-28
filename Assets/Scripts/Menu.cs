using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {


	void Update(){

	}

	public void PlayGame(){
		Time.timeScale = 1;
	}
		
	public	void pause(){
		Time.timeScale = 0;
	}

	public	void resume(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("Level1");
	}


}
