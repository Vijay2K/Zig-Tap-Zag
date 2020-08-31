using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField]
    private float speed;
    bool Started;
    bool gameover;
    public GameObject particle;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Started = false;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Started != true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                Started = true;

                GameManager.Instance.gamestart();
            }
        }

       if( !Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameover = true;
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<cameraFollow>().GameOver = true;

            GameManager.Instance.gameover();
        }

        if(Input.GetMouseButtonDown(0) && !gameover)
        {
            SwitchBall();
        }
    }
    void SwitchBall()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "diamond")
        {
           GameObject _particale = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity)as GameObject;
            Destroy(col.gameObject);
            Destroy(_particale,1f);
        }
    }



}
