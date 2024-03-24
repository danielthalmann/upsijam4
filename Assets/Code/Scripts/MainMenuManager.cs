using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public CanvasGroup creditsGroup;

    public void Play()
    {
        SceneManager.LoadScene("Level");
    }

    public void ShowCredits()
    {
        creditsGroup.alpha = 1;
        creditsGroup.blocksRaycasts = true;
    }

    public void BackFromCredits()
    {
        creditsGroup.alpha = 0;
        creditsGroup.blocksRaycasts = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
