using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool isDeadInside = false;
       
       public float timer;
    public Transform firePoint1;
    public Transform firePoint2;

    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       timer += Time.deltaTime;
    
        if (timer >= 1)
        {   
            if(isDeadInside == false)
            {
                if(Input.GetButtonDown("Fire1"))
                {
                    pistolshoot();
                    FindObjectOfType<AudioManager>().Play("Shot");
                    timer = 0; 
                }
            }
           
        }
    }
    void pistolshoot()
    {
        
        Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        isDeadInside = true;

    }
    
}

