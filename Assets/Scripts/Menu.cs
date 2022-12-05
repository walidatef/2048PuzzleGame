using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    //High Score
	public Text high_score;

    // mute sound
    public AudioSource audio;
    public Button muteButton;
    bool isMute = false;
    public Sprite muteImg,notMuteImg;
    void Update(){

	}

	public void resume(){
		Time.timeScale = 1;
	}
		
	public	void pause(){
		Time.timeScale = 0;
	}

	public	void play(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("Level1");
	}

	public void getHighScore(){
		high_score.text = PlayerPrefs.GetInt ("HighScore", 0).ToString();
		Debug.Log ("High Score is "+PlayerPrefs.GetInt ("HighScore", 0).ToString());
	}
    //-----------------------------------------
    //code of volume slider 
    [SerializeField] Slider VolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Slider"))
        {
            PlayerPrefs.SetFloat("Slider", 1);
            Load();
        }
        else
        {
            Load();

        }


    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        audio.volume = VolumeSlider.value;
        Save();

    }
    void Load()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("Slider");


    }
    void Save()
    {
        PlayerPrefs.SetFloat("Slider", VolumeSlider.value);
    }

  public  void mute() {
        if (PlayerPrefs.GetInt("isMute",0)!=1)
        {
            isMute = true;
            PlayerPrefs.SetInt("isMute", 1);
            audio.Pause();
            muteButton.image.sprite = muteImg;
        }
        else {
            isMute = false;
            PlayerPrefs.SetInt("isMute", 0);
            audio.Play();
            muteButton.image.sprite = notMuteImg;
        }
     
    }
    //----------------------------------------------
}
