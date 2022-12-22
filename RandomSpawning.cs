using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawning : MonoBehaviour
{

    public float timer;
    public float RandomY = 0f;
    public GameObject Bullet;

    public Vector3 SpawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RandomY = Random.Range(-4f, 4f);

        timer += Time.deltaTime;
        if (timer >= 0.25f){
            SpawnLocation = new Vector3(10, RandomY, 0);
            Instantiate(Bullet, SpawnLocation, Quaternion.identity);
            timer = 0;
        }
        

    }
}
