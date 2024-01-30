using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float pipeSpeed = 2.0f;

    private void Update()
    {
        if (!GameManager.gameOver) 
        {
            transform.Translate(-pipeSpeed*Time.deltaTime, 0, 0);
            if (transform.position.x < -10.0f) { Destroy(gameObject); }
        }
    }
}
