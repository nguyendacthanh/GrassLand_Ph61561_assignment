using UnityEngine;

public class NewEmptyCSharpScript: MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển của nhân vật
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Nhận đầu vào từ người chơi
        movement.x = Input.GetAxisRaw("Horizontal"); // Phím trái/phải hoặc A/D
        movement.y = Input.GetAxisRaw("Vertical");   // Phím lên/xuống hoặc W/S
    }

    void FixedUpdate()
    {
        // Cập nhật vị trí của nhân vật dựa trên đầu vào và tốc độ di chuyển
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
