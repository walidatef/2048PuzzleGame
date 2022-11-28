using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GameController : MonoBehaviour {

	//timer
	public Text time_Text;
	int timer = 60;
	//end timer

	// High Score
	int current_score = 0 ;
	//end High Score

	void Start(){
		StartCoroutine (Timer ());
	}

	void Update () {
		
		updateHighScore (current_score);
	
	}

	IEnumerator Timer(){

		while(timer!=0){
			if (timer< 10)
				time_Text.text = "0"+timer;
			else
				time_Text.text =timer.ToString();
			yield return new WaitForSeconds (1);
			timer--;
		}
	}

	void updateHighScore(int current_score){
		if(current_score > PlayerPrefs.GetInt("HighScore",0))
			PlayerPrefs.SetInt("HighScore",current_score);
	}
}
