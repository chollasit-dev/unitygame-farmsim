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
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
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
