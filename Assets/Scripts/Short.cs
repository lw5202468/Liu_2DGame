using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子弹行为
/// </summary>
public class Short : MonoBehaviour {

    #region 1 - 变量

    /// <summary>
    /// 造成伤害
    /// </summary>
    public int damage = 1;


    /// <summary>
    /// 子弹归属，true-敌人的子弹，false-玩家的子弹
    /// </summary>
    public bool isEnemyShot = false;

    #endregion

    // Use this for initialization
    void Start () {
        //子弹只有二十秒的生存时间
        Destroy(gameObject, 20);
	}
}
