using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class GameController : MonoBehaviour {

	public GameObject gameOverWindow;
	public Text textGameOver;
	public GameObject GGWindow;
	public Text level;
	public Text levelInGG;
	public Text TextInStWindow;
	public GameObject StartWindow;
	//effect merge
	public AudioSource mergeEffect; 
	public AudioSource shiftUpEffect;
	
	public Text GGText;
	
	

	// High Score
    [HideInInspector] public	int current_score = 0 ;
	//end High Score

	//current_score
	public Text current_score_text;

	// mute sound
	public new AudioSource audio;
	public Button muteButton;
	public Sprite muteImg, notMuteImg;
	//end mute
	
   
	

	void Start(){
		/*to test
		//PlayerPrefs.SetInt("Level", 1);
		//PlayerPrefs.SetInt("HighScore", 4088);
		*/
		level.text=	PlayerPrefs.GetInt("Level", 1).ToString();
		if (!StartWindow.gameObject.activeSelf)
        {
			if(PlayerPrefs.GetFloat("Level", 1) == 1)
            {
				TextInStWindow.text = "Your goal is to reach 5k score to";

			}
			else if(PlayerPrefs.GetFloat("Level", 1) == 2)
            {
				TextInStWindow.text = "Your goal is to reach 10k score to";
			}
			StartWindow.gameObject.SetActive(true);
			
		}


		loadSettingSound();
		audio.volume = PlayerPrefs.GetFloat("Slider");
	}

	void Update () {
     
		updateHighScore (current_score);

	
	}


	

	void updateHighScore(int current_score){
		if (current_score > PlayerPrefs.GetInt("HighScore", 0))
		{
			PlayerPrefs.SetInt("HighScore", current_score);
			GGText.text = "Congratulations, you have crossed the high score :)";
			GGText.color = Color.yellow;
		}
		
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
	public void gameOver()
    {
		SceneManager.LoadScene("Level1");
	}
	public void showGG()
	{
		if (!GGWindow.gameObject.activeSelf)
		{
			level.text = (int.Parse(level.text) + 1).ToString();
			levelInGG.text = "Up to level "+ level.text;
			PlayerPrefs.SetInt("Level",int.Parse(level.text));
			GGWindow.SetActive(true);
			
		}
	}
	
}
