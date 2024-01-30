using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public bool gameOver = true;
    public int scoreInterval =40;
    public Action BGChange;
    private int score = 0;
    private int BGMoveScore = 40;
    public int Score 
    {
        get => score;
        set
        {
            if (score != value) 
            {
                score = Math.Min(value, 999);
                if (score >= BGMoveScore) 
                {
                    BGMoveScore += scoreInterval;
                    BGChange?.Invoke();
                    player.OnBackground();
                }
            }
        }
    }

    public GameObject pipeSpawn;
    public GameObject coinSpawn;
    public GameObject targetSpawn;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;

    public GameObject Player;

    public GameObject startPanel;
    public GameObject EndPanel;
    public GameObject InGame;

    PlayerJump player;
    GameObject BGM;

    private void Awake()
    {
        startPanel.SetActive(true);
        EndPanel.SetActive(false);
        InGame.SetActive(false);

        pipeSpawn.SetActive(false);
        coinSpawn.SetActive(false);
        targetSpawn.SetActive(false);
    }

    private void Start()
    {
        player = Player.GetComponent<PlayerJump>();
        player.Die += GameOver;
        player.Freeze();

        BGM = transform.GetChild(0).gameObject;
        BGM.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = $"Score : {Score:d3}";
    }

    public void StartButton() 
    {
        gameOver = false;
        startPanel.SetActive(false);
        EndPanel.SetActive(false);
        InGame.SetActive(true);

        player.UnFreeze();
        BGM.SetActive(true);
        pipeSpawn.SetActive(true);
        coinSpawn.SetActive(true);
        targetSpawn.SetActive(true);
    }

    public void ReStartButton() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        gameOver = true;
        player.Freeze() ;
        BGM.SetActive(false);
        pipeSpawn.SetActive(false);
        coinSpawn.SetActive(false);
        targetSpawn.SetActive(false);

        startPanel.SetActive(false);
        InGame.SetActive(false);
        EndPanel.SetActive(true);
        finalScoreText.text = $"Score : {Score:d3}";
    }

    public void ScoreUp(int newScore) 
    {
        Score += newScore;
        player.OnScore();
    }
}
