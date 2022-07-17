using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    //Audio�Ɋւ���t�B�[���h�ϐ�
    [HideInInspector]
    [Tooltip("AudioSource�̕ϐ�")]
    AudioSource _audio;

    [SerializeField]
    [Header("�q�b�g�T�E���h")]
    [Tooltip("�A�C�e���擾���̃T�E���h������ϐ�")]
    AudioClip _audio01;
    //

    /// <summary>
    /// �v���C���[���A�C�e���ɐG�ꂽ���̏���
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�A�C�e�����擾���܂����B");
        _audio.PlayOneShot(_audio01);
        Destroy(this.gameObject);
        
    }
}
