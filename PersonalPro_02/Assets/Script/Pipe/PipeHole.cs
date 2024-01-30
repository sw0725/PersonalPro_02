using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHole : MonoBehaviour
{
    public GameObject PipeUp;
    public GameObject PipeDown;

    float range;
    float min = 7.0f;
    float max = 8.0f;
    Vector3 pos;

    private void OnEnable()
    {
        pos = transform.position;
        range = RandomY();
        PipeUp.transform.position = new Vector3(pos.x, pos.y+range, 0);
        PipeDown.transform.position = new Vector3(pos.x, pos.y-range, 0);
    }

    private float RandomY() 
    {
        float r = Random.Range(min, max);
        return r;
    }
}
