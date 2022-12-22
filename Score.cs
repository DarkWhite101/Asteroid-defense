using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int TotalScore = 0;
    public float timerGRUH;

    public Transform Player;
    public TextMeshProUGUI TEXT_NAME;
    public TextMeshProUGUI HIGHSCORE_TEXT_NAME;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        timerGRUH += Time.deltaTime;
        if(timerGRUH >= 0.5f)
        {
            
            TotalScore += 10;
            TEXT_NAME.SetText(TotalScore.ToString());
            CheckHighscore();

            timerGRUH = 0;
        }
        
    }
    void CheckHighscore()
    {
        if(TotalScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", TotalScore);
            UpdateHighScore();
        }
    }
    void UpdateHighScore()
    {
        HIGHSCORE_TEXT_NAME.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
