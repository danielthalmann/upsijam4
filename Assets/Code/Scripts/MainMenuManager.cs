using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public CanvasGroup creditsGroup;

    public void Play()
    {
        // The MainMenu should have a build index of 0 (File > Build Settings > Scenes In Build)
        int activeSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // Loads the next scene, based on the build index
        SceneManager.LoadScene(activeSceneBuildIndex + 1);
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
}
