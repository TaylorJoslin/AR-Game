using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    public static int Score = 0;
    public static ScoreSystem instance;
    public int ScoreToWin;
    public int SceneToLoad;
    public TMP_Text scoreCount;
    

    public GameObject winText;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }
    void Start()
    {
        Score = 0;
        scoreCount.text = Score.ToString();

        winText.SetActive(false);
    }

    private void Update()
    {
        if (Score == ScoreToWin)
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void AddPoints()
    {
        Score += 1;
        scoreCount.text = Score.ToString();
    }

}
