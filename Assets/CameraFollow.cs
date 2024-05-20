using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float xOffset;

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x + xOffset, transform.position.y, transform.position.z);
        }
    }
}
