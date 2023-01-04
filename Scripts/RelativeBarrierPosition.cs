using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeBarrierPosition : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _right;
    [SerializeField] private BoxCollider2D _left;
    [SerializeField] private BoxCollider2D _bottom;

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        _right.offset = new Vector2(halfWidth, 0);
        _left.offset = new Vector2(halfWidth * (-1), 0);
        _bottom.size = new Vector2(halfWidth * 2, 1);
    }
}
