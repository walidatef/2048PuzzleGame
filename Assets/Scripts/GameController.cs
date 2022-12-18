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

	// mute sound
	public new AudioSource audio;
	public Button muteButton;
	public Sprite muteImg, notMuteImg;
	//end mute

	

	void Start(){
		StartCoroutine (Timer ());
		loadSettingSound();
		audio.volume = PlayerPrefs.GetFloat("Slider");
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

	void loadSettingSound() {
		if (PlayerPrefs.GetInt("isMute", 0) == 1)
		{
			audio.Pause();
			muteButton.image.sprite = muteImg;
		}
		else {
			audio.Play();
			muteButton.image.sprite = notMuteImg;
		}
	}
}
