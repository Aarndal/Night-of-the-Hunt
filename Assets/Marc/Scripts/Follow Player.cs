using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    [SerializeField] private Transform playerPosition;

    private Vector3 currentSpeed;

    private bool canFollow = false;

    private void OnEnable()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            canFollow = true;
        }
    }

    void FixedUpdate()
    {
        if (canFollow == true)
        {
            Vector3 newPos = new Vector3(playerPosition.transform.position.x, playerPosition.transform.position.y, -10f);
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentSpeed, cameraSpeed);
        }

    }
}
