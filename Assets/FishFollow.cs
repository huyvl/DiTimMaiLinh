using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFollow : MonoBehaviour
{
    public Transform playerFish;
    public float followSpeed = 2f;
    public float followDistance = 0.5f;

    private Vector3 lastPlayerPosition;
    private SpriteRenderer playerSpriteRenderer;
    private SpriteRenderer followerSpriteRenderer;

    void Start()
    {
        lastPlayerPosition = playerFish.position;
        playerSpriteRenderer = playerFish.GetComponent<SpriteRenderer>();
        followerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 playerMovement = playerFish.position - lastPlayerPosition;

        if (playerMovement.magnitude > 0.01f)
        {
            Vector3 followDirection = playerMovement.normalized;
            Vector3 targetPosition = playerFish.position - followDirection * followDistance;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);

            lastPlayerPosition = playerFish.position;

            followerSpriteRenderer.flipX = playerSpriteRenderer.flipX;
        }
    }
}
