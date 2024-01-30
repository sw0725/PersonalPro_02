using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipeHole;
    public float spawnTime = 5.0f;
    float min = -5.0f;
    float max = 5.0f;

    private void OnEnable()
    {
        PipeStart();
    }

    private void OnDisable()
    {
        PipeStop();
    }

    void Spawn() 
    {
        GameObject gameObject = Instantiate(pipeHole, PositionY(), Quaternion.identity);
        gameObject.transform.SetParent(transform);
    }

    Vector3 PositionY()
    {
        Vector3 pos = transform.position;
        pos.y += Random.Range(min, max);
        return pos;
    }

    public void PipeStart()
    {
        StartCoroutine(SpawnCoroutine());
    }
    public void PipeStop() 
    {
        StopCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        float timer = spawnTime;
        do
        {
            timer = Random.Range(2.5f, spawnTime);
            Spawn();
            yield return new WaitForSeconds(timer);
        } while (!GameManager.gameOver);
    }
}
