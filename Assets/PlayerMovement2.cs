using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;     
    public float jumpForce = 10f;    

    private Rigidbody2D rb;          
    private float startY;            

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        startY = transform.position.y;    /
    }

    void Update()
    {
        // Pohyb na ose X
        float moveX = 0f;
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f; 
        if (Input.GetKey(KeyCode.RightArrow)) moveX = 1f; 

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y); 
        Debug.Log("Player 2 X Movement: " + moveX);  

        // Skok
        if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Player 2 Jumped"); 
        }

        // Návrat na osu X
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); 
            transform.position = new Vector2(transform.position.x, startY); 
            Debug.Log("Player 2 Reset Y Position"); 
        }
    }
}
