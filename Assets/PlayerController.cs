using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    /// <summary>移動速度</summary>
    [Header("移動速度")]
    [SerializeField] float _moveSpeed = default;
    /// <summary>弾を発射する間隔</summary>
    [Header("弾を発射する間隔")]
    [SerializeField] float _shotDistance = default;
    /// <summary>発射する弾</summary>
    [Header("発射する弾")]
    [SerializeField] GameObject _bullet;
    /// <summary>弾を発射する位置</summary>
    [Header("弾を発射する位置")]
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
