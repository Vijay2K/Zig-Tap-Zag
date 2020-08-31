using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    public GameObject ZigTapZagPanel;
    public GameObject GameOverPanel;
    public GameObject TapText;
    public Text Score;
    public Text HighScore;
    public Text BestScore;

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
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        //HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        TapText.SetActive(false);
        ZigTapZagPanel.GetComponent<Animator>().Play("PanelText");
    }
    public void GameOver()
    {
        Score.text = PlayerPrefs.GetInt ("score").ToString();
        BestScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        GameOverPanel.SetActive(true);

    }
    public void Restart()
    {
        SceneManager.LoadScene("level01");
    }


}
