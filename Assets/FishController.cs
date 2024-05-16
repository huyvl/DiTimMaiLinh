using UnityEngine;

public class FishController : MonoBehaviour {
    public float speed = 5f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleManualInput();
    }

    void HandleManualInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            Vector3 direction = new Vector3(horizontal, vertical, 0).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // Calculate the angle for the fish to face based on movement direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Set the rotation based on the calculated angle
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // Flip the sprite based on horizontal movement direction
            if (horizontal < 0)
            {
                spriteRenderer.flipY = true;
            }
            else
            {
                spriteRenderer.flipY = false;
            }
        }
    }
}