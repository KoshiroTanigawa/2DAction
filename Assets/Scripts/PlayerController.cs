using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("�v���C���[��Rigidbody2D�̕ϐ�")]
    Rigidbody2D _playerRb;

    [SerializeField]
    [Header("�ړ����x")]
    [Tooltip("�v���C���[�̈ړ����x�̕ϐ�")]
    float _playerSpeed = 10;

    [SerializeField]
    [Header("�W�����v��")]
    [Tooltip("�v���C���[�̃W�����v�͂̕ϐ�")]
    float _playerJumpForce = 10;

    [SerializeField]
    [Header("�d�͔{��")]
    [Tooltip("�d�͂̔{���̕ϐ�")]
    float _gravityScale = 1.5f;

    [Tooltip("�n�ʂƐڒn���Ă邩���Ǘ�����t���O")]
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
    /// �v���C���[�̐��������̈ړ��̏���
    /// </summary>
    private void HorizontalMove()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(inputHorizontal * _playerSpeed * Time.deltaTime, 0, 0);
    }

    /// <summary>
    /// �v���C���[�Ƃ̏Փ˂̏���
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
    /// �v���C���[���W�����v���鏈��
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
