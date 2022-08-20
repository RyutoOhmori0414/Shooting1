using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    /// <summary>ˆÚ“®‘¬“x</summary>
    [Header("ˆÚ“®‘¬“x")]
    [SerializeField] float _moveSpeed = default;
    /// <summary>’e‚ð”­ŽË‚·‚éŠÔŠu</summary>
    [Header("’e‚ð”­ŽË‚·‚éŠÔŠu")]
    [SerializeField] float _shotDistance = default;
    /// <summary>”­ŽË‚·‚é’e</summary>
    [Header("”­ŽË‚·‚é’e")]
    [SerializeField] GameObject _bullet;
    /// <summary>’e‚ð”­ŽË‚·‚éˆÊ’u</summary>
    [Header("’e‚ð”­ŽË‚·‚éˆÊ’u")]
    [SerializeField] Transform _muzzlePosition;

    Rigidbody2D _rb;
    float _timer = default;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Move();
        Shot();
    }

    void Move()
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

    void Shot()
    {
        if (Input.GetKey(KeyCode.Z) && !Input.GetButton("Slow"))
        {
            _timer += Time.deltaTime;
            if (_timer > _shotDistance)
            {
                Instantiate(_bullet, _muzzlePosition);
                _timer = 0;
            }
        }
    }
}
