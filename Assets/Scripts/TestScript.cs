using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private float timer = 0f;
    private float limit = 0f;
    private int n = 1;
    void Awake()
    {
        Debug.Log("Awake");
    }
    
    void Start()
    {
        Debug.Log("Start");
    }


    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log($"{n}: {Time.deltaTime}");
        n++;
        if (timer > limit)
        {
            Debug.Log("1 Second");
            timer = 0f;
        }
    }
}
