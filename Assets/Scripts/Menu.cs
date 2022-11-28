using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Text high_score;
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

	public void getHighScore(){
		high_score.text = PlayerPrefs.GetInt ("HighScore", 0).ToString();
		Debug.Log ("High Score is "+PlayerPrefs.GetInt ("HighScore", 0).ToString());
	}
}
