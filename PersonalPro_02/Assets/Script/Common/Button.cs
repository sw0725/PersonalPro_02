using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject manager;
    
    GameManager gameManager;
    PlayerJump player;
    Action onPlayButton;
    
    private void Awake()
    {
        gameManager = manager.GetComponent<GameManager>();
        player = gameManager.Player.GetComponent<PlayerJump>();
        onPlayButton += player.OnButton;
    }

    public void OnClick() 
    {
        gameManager.StartButton();
        onPlayButton?.Invoke();
    }

    public void OnReClick()
    {
        gameManager.ReStartButton();
    }

    public void OnGameExit()
    {
        #if UNITY_EDITOR
            Debug.Log("종료버튼");
        #else
            Application.Quit();
        #endif
    }
}
