using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text scoreUI;

    int score;
    void Awake()
    {
        instance = this;
    }
    public void SetScore(int amount)
    {
        score += amount;
        scoreUI.text = score.ToString("D9");
        //CalculateLevel();
        //UIHandler.instance.UpdateUi(score, level, layersCleared);
        // Update UI
    }
}
