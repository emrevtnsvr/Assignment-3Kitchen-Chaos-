using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum DIFFICULTY
    {
        easy,medium,hard
    }
    public DIFFICULTY difficulty = DIFFICULTY.easy;
    public FailController FailController;   
    public int Score;
    public TextMeshProUGUI ScoreText;
    public Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Score = 0;
        SetScoreText();
    }
    public void SetScoreText()
    {
        ScoreText.text = "Score: " + Score.ToString();
    }
    public void AddScore(int val)
    {
        Score += val;
        ScoreText.text = "Score: " + Score.ToString();
    }

    public void OnFail()
    {
        FailController.OpenFailPanel();
    }
    public void GiveReward()
    {
        playerHealth.AddHealth(3);
    }

}
