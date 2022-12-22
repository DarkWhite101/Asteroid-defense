using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
   
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)") 
        {
            
            Destroy(collision.gameObject);
            
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2 (40f, 0f );
    }
    
}
