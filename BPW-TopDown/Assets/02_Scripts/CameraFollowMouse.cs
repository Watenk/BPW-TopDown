using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public Camera cam;
    public Transform player;
    public float xDistance;
    public float yDistance;

    public void OnUpdate()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = (player.position + mousePos) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -xDistance + player.position.x, xDistance + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -yDistance + player.position.y, yDistance + player.position.y);
        targetPos.z = 0;

        gameObject.transform.position = targetPos;
    }
}