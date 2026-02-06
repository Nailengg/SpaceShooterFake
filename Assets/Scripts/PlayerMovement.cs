using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        Vector3 mPos = Input.mousePosition;
        mPos.x = Mathf.Clamp(mPos.x, 0, Screen.width);
        float maxY = Screen.height * 2f/3f;
        mPos.y = Mathf.Clamp(mPos.y, 0, maxY);
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mPos);
        worldPoint.z = 0;
        transform.position = worldPoint;
    }
}
