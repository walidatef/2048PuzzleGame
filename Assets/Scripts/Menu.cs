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
    //-----------------------------------------
    //code of volume slider 
    [SerializeField] Slider VolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
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
        AudioListener.volume = VolumeSlider.value;
        Save();

    }
    void Load()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");


    }
    void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", VolumeSlider.value);
    }
    //----------------------------------------------
}
