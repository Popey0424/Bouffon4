using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    public AudioMixer Mixer;
    public AudioSource Music;
   

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();

    }

    public void OnMusicValueChanged(float newValue)
    {
        Music.volume = newValue;
    }

    //public void OnSFXValuechanged(float newValue)
    //{
    //    if (newValue < 0.01f)
    //        newValue = 0.01f;

    //    float volume = Mathf.Log10(newValue) * 20;

    //    Mixer.SetFloat("SFX_Volumle", volume);
    //}

}


