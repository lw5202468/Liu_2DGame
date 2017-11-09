using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 发射子弹
/// </summary>
public class WeaponScript : MonoBehaviour {

    #region 1 - 变量

    /// <summary>
    /// 子弹预设
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// 两法子弹之间的发送间隔
    /// </summary>
    public float shotingRate = 0.25f;

    /// <summary>
    /// 当前冷却时间
    /// </summary>
    private float shotCooldown;

    #endregion

    // Use this for initialization
    void Start () {
        shotCooldown = 0f;
	}

    private void Update()
    {
        if (shotCooldown > 0 )
        {
            shotCooldown -= Time.deltaTime;
        }
    }

    /// <summary>
    /// 发射子弹
    /// </summary>
    /// <param name="isEnemy"></param>
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            //if (isEnemy)
            //{
            //    SoundEffectsHelper.Instance.MakeEnemyShotSound();
            //} else
            //{
            //    SoundEffectsHelper.Instance.MakePlayerShotSound();
            //}

            shotCooldown = shotingRate;

            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = transform.position;
            Short shot = shotTransform.gameObject.GetComponent<Short>();

            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.direction = move.direction;
            }
        }
    }

    public bool CanAttack
    {
        get
        {
            return shotCooldown <= 0f;
        }
    }
}
