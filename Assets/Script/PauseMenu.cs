using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuPause;
    [SerializeField] private Image ImageFade;

    public void OnClickPause()
    {
        Time.timeScale = 0f;
        MenuPause.SetActive(true);
    }

    public void OnClickResume()
    {
        Time.timeScale = 1f;
        MenuPause.SetActive(false);
    }

    public void OnClickLeave()
    {
        ImageFade.DOFade(1, 2.9f).OnComplete(FadeComplete);
        Time.timeScale = 1f;
    }

    public void FadeComplete()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickExit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
