using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text scoreUI;
    public TMP_Text gameOverScoreUi;
    public GameObject gameOverScreen;

    public AudioSource brokenChord;

    int score;

    public bool isGameOver;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameOverScreen.SetActive(false);   
    }
    public void SetScore(int amount)
    {
        score += amount;
        scoreUI.text = score.ToString("D9");
        //CalculateLevel();
        //UIHandler.instance.UpdateUi(score, level, layersCleared);
        // Update UI
    }
    public void SetGameOverScreen()
    {
        brokenChord.Play();
        gameOverScreen.SetActive(true);
        gameOverScoreUi.text = "Score: " + score.ToString("D9");
    }
}
