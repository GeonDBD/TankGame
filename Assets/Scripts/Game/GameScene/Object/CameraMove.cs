using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform targetPlayer;
    public float H = 10;

    private Vector3 pos;

    private void LateUpdate()
    {
        if (targetPlayer == null) return;
        // x、z和玩家保持一致，即跟随玩家
        // 获取玩家位置
        pos.x = targetPlayer.position.x;
        pos.z = targetPlayer.position.z;
        pos.y = H;
        // 改变摄像机位置
        transform.position = pos;
    }
}
