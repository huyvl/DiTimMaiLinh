using System;
using System.Collections;
using UnityEngine;

public class FishController : MonoBehaviour {
    public float speed = 5f;

    private SpriteRenderer spriteRenderer;
    private bool isStun;
    public float upperBound = 5f; 
    public float lowerBound = -5f;

    private int health = 3;
    
    public int Health
    {
        get { return health; }
        set
        {
            health = Mathf.Clamp(value, 0, 3);
        }
    }
    void Start() {
        Health = 3;
        spriteRenderer = GetComponent<SpriteRenderer>();
        var mainCamera = Camera.main;
        float halfCameraHeight = mainCamera.orthographicSize;

        lowerBound = mainCamera.transform.position.y - halfCameraHeight;
        upperBound = mainCamera.transform.position.y + halfCameraHeight;
    }

    void Update()
    {
        HandleManualInput();
    }

    void HandleManualInput()
    {
        if (!GameManager.Instance.isInPlay) return;
        if (isStun) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            Vector3 direction = new Vector3(horizontal, vertical, 0).normalized;
            Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

            newPosition.y = Mathf.Clamp(newPosition.y, lowerBound, upperBound);

            transform.position = newPosition;

            if (horizontal < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (horizontal > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    IEnumerator  DizzyEffect() {
        isStun = true;
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(0.1f, 0.2f));
        yield return new WaitForSeconds(1f);
        Camera.main.GetComponent<CameraFollow>().enabled = true;
        isStun = false;
    }
    //TO-DO: Tach phan xu ly nay ra sau
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Coin")) {
            Destroy(other.gameObject);
            SoundManager.instance.Play(TypeSFX.SFX,"Eat");
            GameManager.Instance.UpdateScore(1);
        }
        else if (other.CompareTag("Obstacles")) {
            StartCoroutine(DizzyEffect());
        }
        else if (other.CompareTag("Cave")) {
            GameManager.Instance.QuizTime();
        }
    }
}