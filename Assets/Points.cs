using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Points : MonoBehaviour
{
    public static Points instance;

    public Text scoreText;
    public Text highScoreText;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;
        highScore = 0;
    }
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = score.ToString() + " SCORE";
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    public void AddPoints()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
        if(highScore < score)
        PlayerPrefs.SetInt("highScore", score);
    }
}
