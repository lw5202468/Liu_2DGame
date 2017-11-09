using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 创建音效实例
/// </summary>
public class SoundEffectsHelper : MonoBehaviour {

    /// <summary>
    /// 静态实例
    /// </summary>
    public static SoundEffectsHelper Instance;

    public AudioClip explosionSound;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper");
        }
        Instance = this;
    }

    public void MakeExplosionSound()
    {
        MakeSound(explosionSound);
    }

    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound);
    }

    public void MakeEnemyShotSound()
    {
        MakeSound(enemyShotSound);
    }

    /// <summary>
    /// 播放给定的音效
    /// </summary>
    /// <param name="originalClip"></param>
    private void MakeSound(AudioClip originalClip)
    {
        if (Instance != null)
        {
            AudioSource.PlayClipAtPoint(originalClip, transform.position);
        }
    }
}
