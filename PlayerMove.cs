
using UnityEngine;
using System.Collections;
using System;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float gridSpacing = 0.5f; // 格子间距
    [SerializeField] private float teleportCooldownTime = 0.4f; // 瞬移冷却时间

    private Rigidbody2D rb;

    private Vector2 moveDirection;
    private float nextTeleportTime = 0f; // 下次可瞬移的时间
    public ParticleSystem playerPS;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // 获取玩家输入方向
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //如果玩家进行输入操作，并且时间大于冷却时间
        if (inputDirection.sqrMagnitude > 0.0f && Time.time >= nextTeleportTime)
        {
            // 确保输入方向为单位向量
            inputDirection.Normalize();

            // 计算目标移动距离（等于格子间距）
            float targetMoveDistance = gridSpacing;

            // 计算实际移动方向和距离
            moveDirection = inputDirection * targetMoveDistance;

            // 瞬移到新的位置
            rb.position += moveDirection;
            //下次可瞬移的时间
            nextTeleportTime = Time.time + teleportCooldownTime;
            //播放动画特效
            playerPS.Play();
        }//未进行操作，或者是未到移动的冷却时间
        else
        {
            //暂停动画特效
            playerPS.Stop();
        }
    }
}

