using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{   // 최대 -8top -5middle  기본 -12top -7middel 최소 -16top -9middle
    public float scrollingSpeed = 2.5f;
    public float upDownSpeed = 0.1f;

    public bool WillMove = false;
    public bool Front = false;

    const float BackgroundWidth = 20.0f;
    const float min = -2.0f;
    const float max = 2.0f;

    protected Transform[] bgSloats;
    GameManager manager;

    float baseLineX;
    Vector3 basePos;

    protected virtual void Awake()
    {
        manager = FindAnyObjectByType<GameManager>();
        bgSloats = new Transform[transform.childCount];
        for (int i = 0; i < bgSloats.Length; i++)
        {
            bgSloats[i] = transform.GetChild(i);
        }

        baseLineX = transform.position.x - BackgroundWidth;
        basePos = transform.position;
        manager.BGChange += Trigger;
    }

    private void Update()
    {
        for (int i = 0; i < bgSloats.Length; i++)
        {
            bgSloats[i].Translate(Time.deltaTime * scrollingSpeed * -transform.right);

            if (bgSloats[i].position.x < baseLineX)
            {
                MoveRight(i);
            }
        }
    }

    protected virtual void MoveRight(int index)
    {
        bgSloats[index].Translate(BackgroundWidth * bgSloats.Length * transform.right);
    }

    private Vector3 RandomY()
    {
        Vector3 pos = basePos;
        float moveY = Random.Range(min, max);
        if (Front) { moveY += moveY; }
        pos.y += moveY;
        return pos;
    }

    IEnumerator MoveUpDown()
    {
        Vector3 ditermination = RandomY();
        if (WillMove)
        {
            while (transform.position.y != ditermination.y)
            {
                for (int i = 0; i < bgSloats.Length; i++)
                {
                    transform.position = Vector3.MoveTowards(transform.position, ditermination, upDownSpeed);
                }
                yield return null;
            }
        }
    }

    public void Trigger()
    {
        StartCoroutine(MoveUpDown());
    }
}
