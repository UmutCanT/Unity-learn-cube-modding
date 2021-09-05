using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        transform.position = MousePosition();
    }

    Vector3 MousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = (Camera.main.nearClipPlane + Camera.main.farClipPlane) / 2;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
