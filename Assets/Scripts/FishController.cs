using System;
using System.Collections;
using UnityEngine;

public class FishController : MonoBehaviour {
    public float speed = 5f;

    private SpriteRenderer spriteRenderer;
    private bool isStun;

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
        if(!GameManager.Instance.isInPlay) return;
        if(isStun) return;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            Vector3 direction = new Vector3(horizontal, vertical, 0).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //
            // transform.rotation = Quaternion.Euler(0, 0, angle);

            if (horizontal < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    IEnumerator  DizzyEffect() {
        isStun = true;
        yield return new WaitForSeconds(1f);
        isStun = false;
    }
    //TO-DO: Tach phan xu ly nay ra sau
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Coin")) {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Obstacles")) {
            StartCoroutine(DizzyEffect());
        }
        else if (other.CompareTag("Cave")) {
            GameManager.Instance.QuizTime();
        }
    }
}