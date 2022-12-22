using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name != "WallEnd")
        {
            if(collision.gameObject.name != "Bullet(Clone)")
            {
                FindObjectOfType<AudioManager>().Play("AsteroidExplode");
                Destroy(gameObject);
            }
        }
        
        Destroy(gameObject);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2 (-20f, 0f );
    }


}
