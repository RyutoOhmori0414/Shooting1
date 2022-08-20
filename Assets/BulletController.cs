using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    /// <summary>弾のスピード</summary>
    [Tooltip("弾のスピード")]
    [SerializeField] float _bulletSpeed = default;
    //Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, _bulletSpeed), ForceMode2D.Impulse);
    }
}
