using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    //Audioに関するフィールド変数
    [HideInInspector]
    [Tooltip("AudioSourceの変数")]
    AudioSource _audio;

    [SerializeField]
    [Header("ヒットサウンド")]
    [Tooltip("アイテム取得時のサウンドを入れる変数")]
    AudioClip _audio01;
    //

    /// <summary>
    /// プレイヤーがアイテムに触れた時の処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("アイテムを取得しました。");
        _audio.PlayOneShot(_audio01);
        Destroy(this.gameObject);
        
    }
}
