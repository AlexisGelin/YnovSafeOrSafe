using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] float offSetX,offSetY = 2;

    private void Start()
    {
        transform.position = new Vector3(player.position.x + offSetX, player.position.y + offSetY, transform.position.z);
    }


    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x + offSetX, player.position.y + offSetY, transform.position.z);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
    }
}
