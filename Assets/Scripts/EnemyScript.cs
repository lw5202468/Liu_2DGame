using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人通用行为
/// </summary>
public class EnemyScript : MonoBehaviour {

    #region 变量

    private WeaponScript weapon;

    #endregion

    private void Awake()
    {
        weapon = GetComponent<WeaponScript>();
    }

    private void Update()
    {
        if (weapon != null && weapon.CanAttack)
        {
            weapon.Attack(true);
        }
    }
}
