using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家控制器行为
/// </summary>
public class Player : MonoBehaviour {

    #region 1 - 变量

    /// <summary>
    /// 移动速度
    /// </summary>
    private Vector2 speed = new Vector2(20, 20);

    //存储移动
    private Vector2 movement;

    #endregion

    // Use this for initialization
    void Start () {
		
	}

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        bool shoot = Input.GetButtonDown("Fire1");
        //shoot != Input.GetButtonDown("Fire2");

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }
    }

    private void FixedUpdate()
    {
        transform.GetComponent<Rigidbody2D>().velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.ToString().IndexOf("Poulpi") >= 0)
        {
            bool damagePlayer = false;

            //与敌人发生碰撞
            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                //杀死敌人
                HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
                if (enemyHealth != null)
                {
                    enemyHealth.Damage(enemyHealth.hp);
                }

                damagePlayer = true;
            }

            if (damagePlayer)
            {
                HealthScript playerHealth = this.GetComponent<HealthScript>();
                if (playerHealth != null)
                {
                    playerHealth.Damage(1);
                }
            }
        }
    }
}
