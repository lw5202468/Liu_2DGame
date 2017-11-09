using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪物脚本
/// </summary>
public class MoveScript : MonoBehaviour {

    #region 1 - 变量

    /// <summary>
    /// 怪物移动速度
    /// </summary>
    public Vector2 speed = new Vector2(10, 10);

    /// <summary>
    /// 移动方向
    /// </summary>
    public Vector2 direction = new Vector2(1, 0);

    //存储移动
    private Vector2 movement;

    #endregion

    // Use this for initialization
    void Start () {
		
	}

    private void Update()
    {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
    }

    private void FixedUpdate()
    {
        transform.GetComponent<Rigidbody2D>().velocity = movement;
    }
}
