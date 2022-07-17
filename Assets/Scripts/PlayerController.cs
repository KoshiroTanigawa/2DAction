using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("プレイヤーのRigidbody2Dの変数")]
    Rigidbody2D _playerRb;

    [SerializeField]
    [Header("移動速度")]
    [Tooltip("プレイヤーの移動速度の変数")]
    float _playerSpeed = 10;

    [SerializeField]
    [Header("ジャンプ力")]
    [Tooltip("プレイヤーのジャンプ力の変数")]
    float _playerJumpForce = 10;

    [SerializeField]
    [Header("重力倍率")]
    [Tooltip("重力の倍率の変数")]
    float _gravityScale = 1.5f;

    [Tooltip("地面と接地してるかを管理するフラグ")]
    bool _onGround;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity = new Vector3(0, _gravityScale, 0);
    }

    void Update()
    {
        HorizontalMove();
        Jump();
    }

    /// <summary>
    /// プレイヤーの水平方向の移動の処理
    /// </summary>
    private void HorizontalMove()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(inputHorizontal * _playerSpeed * Time.deltaTime, 0, 0);
    }

    /// <summary>
    /// プレイヤーとの衝突の処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            _onGround = true;
        }
    }

    /// <summary>
    /// プレイヤーがジャンプする処理
    /// </summary>
    private void Jump()
    {
        Vector2 jump = new Vector2(0, _playerJumpForce);
        if (Input.GetKey(KeyCode.Space) && _onGround)
        {
            _playerRb.AddForce(jump, ForceMode2D.Impulse);
            _onGround = false;
        }
    }
}
