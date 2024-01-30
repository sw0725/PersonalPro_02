using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    public float TimeGap = 16.0f;
    public float TimeAfter = 4.0f;

    public float rocketMin = -4.0f;
    public float rocketMax = 4.0f;

    GameObject target;
    GameObject rocket;
    Target Target;

    private void OnEnable()
    {
        target = transform.GetChild(0).gameObject;
        rocket = transform.GetChild(1).gameObject;
        target.SetActive(false);
        rocket.SetActive(false);

        Target = target.GetComponent<Target>();
        Target.targetDown += ReStart;

        TargetStart();
    }

    private void OnDisable()
    {
        TargetStop();
        Target.targetDown -= ReStart;
    }

    private void ReStart() 
    {
        TargetStart();
    }

    void TargetSpawn()
    {
        target.transform.position = RandomPotition();
        target.SetActive(true);
    }
    void RocketSpawn()
    {
        rocket.transform.position = RandomPotition();
        rocket.SetActive(true);
        StopAllCoroutines();
    }

    private Vector3 RandomPotition()
    {
        Vector3 pos = transform.position;
        pos.y += Random.Range(rocketMin, rocketMax);
        return pos;
    }

    public void TargetStart()
    {
        StartCoroutine(TargetSpawnCoroutine());
        StartCoroutine(RocketSpawnCoroutine());
    }
    public void TargetStop()
    {
        StopCoroutine(TargetSpawnCoroutine());
        StopCoroutine(RocketSpawnCoroutine());
    }

    IEnumerator TargetSpawnCoroutine()
    {
        do
        {
            yield return new WaitForSeconds(TimeGap);
            TargetSpawn();
        } while (!GameManager.gameOver);
    }

    IEnumerator RocketSpawnCoroutine()
    {
        do
        {
            yield return new WaitForSeconds(TimeGap+TimeAfter);
            RocketSpawn();
        } while (!GameManager.gameOver);
    }
}
