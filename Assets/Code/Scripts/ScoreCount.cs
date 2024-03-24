using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreCount : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI scoreTextInfected;

    public Field field;

    public static ScoreCount Instance;

    public int scoreMultiplier = 4;

    private int _scoreCount = 0;

    private uint fieldChickenCount = 0;

    private int _infectedChickenCount = 0;

    public int _healthyChickenCount = 0;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        fieldChickenCount = field.chickenCount;
    }

    private void FixedUpdate()
    {
        var chickens = field.stats.chickens;
        var infectedCount = 0;

        if (chickens.Length > 0)
        {
            foreach (var chicken in chickens)
            {
                if (chicken.IsInfected())
                {
                    infectedCount += 1;
                }
            }
        }

        _infectedChickenCount = infectedCount;
    }

    private void LateUpdate()
    {
        _healthyChickenCount = (int) fieldChickenCount - _infectedChickenCount;

        scoreText.SetText(_healthyChickenCount.ToString());
        scoreTextInfected.SetText(_infectedChickenCount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        /*float currentScore = scoreCount;
        float currentSeconds = GetCurrentSeconds();
        float currentScoreMultiplier = scoreMultiplier;

        if (currentSeconds > secondsToMultiplier)
        {
            currentScoreMultiplier = GetMultiplier();
        }

        float score = currentScoreMultiplier * currentSeconds;

        scoreCount = Mathf.RoundToInt(score);

        // Scene
        Scene m_Scene = SceneManager.GetActiveScene();
        string sceneName = m_Scene.name;

        if (m_Scene != null && sceneName != "Game")
        {
            scoreText.SetText("");
        }
        else
        {
            scoreText.SetText(scoreCount.ToString());
        }*/
    }

    /*public float GetMultiplier()
    {
        float currentSeconds = GetCurrentSeconds();
        return scoreMultiplier + (currentSeconds / secondsToMultiplier);
    }*/

    /*public int GetScoreCount()
    {
        return scoreCount;
    }*/
}

