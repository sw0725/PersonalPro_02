using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotateSpeed = 10.0f;

    public GameObject targeting;

    GameObject target;
    Vector3 targetpoint;
    Vector3 rocketPoint;

    public bool isOn = false;

    private void Awake()
    {
        target = targeting.transform.GetChild(0).gameObject;
    }

    private void OnEnable()
    {
        targetpoint = target.transform.position;
        rocketPoint = transform.position;
        isOn = true;
    }

    private void OnDisable()
    {
        isOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isOn) 
        {
            targetpoint = target.transform.position;
            rocketPoint = transform.position;
            
            transform.right = -Vector3.Slerp(-transform.right, targetpoint - rocketPoint, Time.deltaTime*rotateSpeed);
            transform.Translate(Time.deltaTime * speed * -transform.right, Space.World);
        }
    }
}
