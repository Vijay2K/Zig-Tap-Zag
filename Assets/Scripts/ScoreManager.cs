using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;
    public int score;
    public int HighScore;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreIncrement()
    {
        score += 1;
    }
    public void ScoreStart()
    {
        InvokeRepeating("ScoreIncrement", 0.1f, 0.5f);
    }
    public void StopScore()
    {
        CancelInvoke("ScoreIncrement");
        PlayerPrefs.SetInt("score", score);

        if(PlayerPrefs.HasKey("HighScore"))
        {
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            else
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
    }
}
