using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Vector3 offset;
        private GameObject playerObject;

        private void Start()
        {
            this.playerObject = GameObject.Find("Player");
        }

        private void Update()
        {
            Vector3 desiredPosition = this.playerObject.transform.position + this.offset;
            Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, desiredPosition, 0.125f);
            this.transform.position = smoothedPosition;
        }
    }
}