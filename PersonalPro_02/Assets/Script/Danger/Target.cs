using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float followTimer = 8.0f;
    public GameObject explosion;
    public float speed = 9.0f;

    public Action targetDown;

    GameManager manager;
    GameObject player;

    protected virtual void Awake()
    {
        manager = FindAnyObjectByType<GameManager>();
        player = manager.Player;
    }

    private void OnEnable()
    {
        StartCoroutine(Follow(followTimer));
    }

    private void OnDisable()
    {
        StopCoroutine(Follow(followTimer));
        if(!GameManager.gameOver) targetDown?.Invoke();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rocket")) 
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }

    protected virtual IEnumerator Follow(float followTime) 
    {
        float timer = 0.0f;
        Vector3 direction;
        while (timer < 1.0f) 
        {
            timer += Time.deltaTime / followTime;

            direction = player.transform.position - transform.position;
            if (direction.sqrMagnitude > 0.01)
            {
                transform.Translate((direction.normalized) * speed * Time.deltaTime);
            }
            else 
            {
                transform.position = player.transform.position;
            }

            yield return null;
        }

    }
}
