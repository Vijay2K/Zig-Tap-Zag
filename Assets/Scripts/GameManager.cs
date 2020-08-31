using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public bool GameOver;

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
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gamestart()
    {
        UIManager.Instance.GameStart();
        ScoreManager.Instance.ScoreStart();

        
    }
    public void gameover()
    {
        UIManager.Instance.GameOver();
        ScoreManager.Instance.StopScore();
        GameOver = true;
        
    }
}
