using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreZone : MonoBehaviour
{
    public Action<int> GetScore;
    public int Score = 1;

    GameManager manager;

    private void OnEnable()
    {
        manager = FindAnyObjectByType<GameManager>();
        GetScore += manager.ScoreUp;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            GetScore?.Invoke(Score);
            Destroy(gameObject);
        }
    }
}
