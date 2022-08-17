using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    /// <summary>ˆÚ“®‘¬“x</summary>
    [SerializeField] float _moveSpeed = default;
    Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(h, v).normalized;
        if (Input.GetButton("Slow"))
        {
            dir = dir / 2;
        }
        _rb.velocity = dir * _moveSpeed;
    }
}
