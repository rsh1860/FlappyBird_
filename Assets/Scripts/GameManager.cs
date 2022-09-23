using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStart = false;
    public bool isBirdDead = false;

    public GameObject readyUI;
    public GameObject playUI;
    public GameObject resultUI;

    public int score = 0;
    public int bestScore = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        InitData();
    }

    private void InitData()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPlay()
    {
        isStart = true;
        readyUI.SetActive(false);
        playUI.SetActive(true);
    }

    public void GameOver()
    {
        resultUI.SetActive(true);
    }
}
