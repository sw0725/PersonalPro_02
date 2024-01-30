using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guid : MonoBehaviour
{
    GameObject guid;

    private void OnEnable()
    {
        Destroy(gameObject, 3.0f);
    }
}
