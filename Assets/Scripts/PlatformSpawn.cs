using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{

    public GameObject platform;
    Vector3 lastpos;
    float size;
    public bool gameOver;
    public GameObject diamond;

    // Start is called before the first frame update
    void Start()
    {
        lastpos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatForm();
        }

        InvokeRepeating("SpawnPlatForm", 0.1f, 0.2f);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GameOver == true)
        {
            CancelInvoke("SpawnPlatForm");
        }
    }
    void SpawnPlatForm()
    {
        int random = Random.Range(0, 6);
        if(random < 3)
        {
            SpawnX();
        }
        else if(random >= 3)
        {
            SpawnZ();
        }
    }



    void SpawnX()
    {
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos;

        Instantiate(platform, pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond,new Vector3(pos.x,pos.y + 1,pos.z),diamond.transform.rotation );
        }

    }
    void SpawnZ()
    {
        Vector3 pos = lastpos;
        pos.z += size;
        lastpos = pos;

        Instantiate(platform, pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond,new Vector3(pos.x,pos.y + 1,pos.z),diamond.transform.rotation );
        }
    }

}
