
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;     // Rychlost pohybu na ose X
    public float jumpForce = 10f;   // Síla skoku na ose Y

    private Rigidbody2D rb;         // Reference na Rigidbody2D
    private float startY;           // Výchozí pozice na ose Y

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Najdeme Rigidbody2D
        startY = transform.position.y;    // Uložíme počáteční pozici na ose Y
    }

    void Update()
    {
        // Pohyb na ose X
        float moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f; // Dozadu
        if (Input.GetKey(KeyCode.D)) moveX = 1f;  // Dopředu

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // Skok
        if (Input.GetKeyDown(KeyCode.W) && Mathf.Abs(rb.linearVelocity.y) < 0.01f) 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Návrat na osu X
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Zastavíme pohyb na Y
            transform.position = new Vector2(transform.position.x, startY); // Reset pozice Y
        }
    }
}


    

