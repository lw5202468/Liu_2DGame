using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 处理生命值和伤害
/// </summary>
public class HealthScript : MonoBehaviour {

    #region 1 - 变量

    /// <summary>
    /// 总生命值
    /// </summary>
    public int hp = 1;

    /// <summary>
    /// 敌人标识
    /// </summary>
    public bool isEnemy = true;

    #endregion
    
    /// <summary>
    /// 对敌人造成伤害并检查对象是否应该被销毁
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            //死亡
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Short shot = collision.gameObject.GetComponent<Short>();
        if (shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                Destroy(shot.gameObject);
            }
        }
    }
}
