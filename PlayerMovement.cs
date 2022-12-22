using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public GameObject Respawn_GUI;
    float timer;

    public float MoveSpeed;
    public Rigidbody2D rb;
    public bool isDeadInside = false;
    public bool slowmoOn = false;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        slowmoOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        if(isDeadInside == false)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                slowmoOn = true;

                if(slowmoOn == true)
                {
                Time.timeScale = 0.1f;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                MoveSpeed += 25;
                }
                
            }
            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                slowmoOn = false;
                if (slowmoOn == false)
                {
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                MoveSpeed -= 25;
                }
            }
        }
    }
    void FixedUpdate()
    {
        Move();
    }
    
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);

    }
    
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * MoveSpeed, moveDirection.y * MoveSpeed);
    }


     void OnCollisionEnter2D(Collision2D collision)
    {
       
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        
        isDeadInside = true;
        Respawn_GUI.SetActive(true);
        Time.timeScale = 0;
        
        
    }

    // Update is called once per frame
     void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Reset Game");
    }
}

