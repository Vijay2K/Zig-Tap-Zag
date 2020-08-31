using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public GameObject ball;
    Vector3 offset;
    public float LerpRate;
     public bool GameOver;



    // Start is called before the first frame update
    void Start()
    {
        offset = ball.transform.position - transform.position;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetpos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetpos, LerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
