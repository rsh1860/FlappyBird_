using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DrawResultUI : MonoBehaviour
{
    public GameManager gameManager;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;


    public TextMeshProUGUI newText;

    private void OnEnable()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (PlayerPrefs.GetInt("BestScore") < gameManager.score)
        {
            newText.text = "NEW!";
            PlayerPrefs.SetInt("BestScore", gameManager.score);
        }
        else if (PlayerPrefs.GetInt("BestScore") == gameManager.score)
        {
            newText.text = "SAME";
        }
        else
        {
            newText.enabled = false;
        }
    }

    void Start()
    {
        scoreText.text = gameManager.score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", gameManager.score).ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
