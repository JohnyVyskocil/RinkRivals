
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;     
    public float jumpForce = 10f;   

    private Rigidbody2D rb;        
    private float startY;           

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        startY = transform.position.y;    
    }

    void Update()
    {
        // Pohyb na ose X
        float moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f; 
        if (Input.GetKey(KeyCode.D)) moveX = 1f;  

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

 
        if (Input.GetKeyDown(KeyCode.W) && Mathf.Abs(rb.linearVelocity.y) < 0.01f) 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

 
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); 
            transform.position = new Vector2(transform.position.x, startY); 
        }
    }
}


    

