using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;     // Rychlost pohybu na ose X
    public float jumpForce = 10f;    // Síla skoku na ose Y

    private Rigidbody2D rb;          // Reference na Rigidbody2D
    private float startY;            // Výchozí pozice na ose Y

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Najdeme Rigidbody2D
        startY = transform.position.y;    // Uložíme počáteční pozici na ose Y
    }

    void Update()
    {
        // Pohyb na ose X
        float moveX = 0f;
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f; // Dozadu
        if (Input.GetKey(KeyCode.RightArrow)) moveX = 1f; // Dopředu

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y); // Používáme velocity místo linearVelocity
        Debug.Log("Player 2 X Movement: " + moveX);  // Debug: Zobrazí hodnotu pohybu X

        // Skok
        if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Player 2 Jumped"); // Debug: Zobrazí, že hráč skočil
        }

        // Návrat na osu X
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Zastavíme pohyb na Y
            transform.position = new Vector2(transform.position.x, startY); // Reset pozice Y
            Debug.Log("Player 2 Reset Y Position"); // Debug: Zobrazí, že pozice Y byla resetována
        }
    }
}
