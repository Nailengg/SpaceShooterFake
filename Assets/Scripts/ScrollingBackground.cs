using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Renderer bgRenderer;
    public float speed = 0.1f;

    void Update()
    {
        bgRenderer.material.mainTextureOffset =
            new Vector2(0, Time.time * speed);
    }
}