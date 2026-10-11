using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 依作業規範使用 Vector3 陣列依序記錄路徑點
    private Vector3[] targets;
    private int currentTargetIndex = 0;

    [Header("移動速度")]
    public float walkSpeed = 3.5f; // 地面行走速度
    public float jumpSpeed = 5.0f; // 空中跳躍速度

    void Start()
    {
        // 抓取角色的初始地面高度 (Y 軸)，確保走路時完全水平不歪斜
        float groundY = transform.position.y;

        // 宣告長度為 5 的 Vector3 陣列
        targets = new Vector3[5];

        // 點 0：往前走到安全起跳點 (X = -6.5，遠離方塊左側邊緣)
        targets[0] = new Vector3(-6.5f, groundY, 0f);

        // 點 1：原地直直上跳拔高 (高度抬高 +6.0，遠高於方塊頂端)
        targets[1] = new Vector3(-6.0f, groundY + 6.0f, 0f);

        // 點 2：在極高空橫跨越過方塊 (飛到方塊右上方)
        targets[2] = new Vector3(0.5f, groundY + 6.0f, 0f);

        // 點 3：下跳落回地面 (落到右側地面 X = 3.0)
        targets[3] = new Vector3(3.0f, groundY, 0f);

        // 點 4：下跳後再往前走一段距離 (平移前進到終點 X = 6.5，Y 軸保持地面高度)
        targets[4] = new Vector3(6.5f, groundY, 0f);
    }

    void Update()
    {
        if (currentTargetIndex < targets.Length)
        {
            // 在地面走路時 (第 0 段與第 4 段) 使用 walkSpeed；跳躍空中階段使用 jumpSpeed
            float speed = (currentTargetIndex == 0 || currentTargetIndex == 4) ? walkSpeed : jumpSpeed;

            // 朝當前陣列目標平滑移動
            transform.position = Vector3.MoveTowards(
                transform.position,
                targets[currentTargetIndex],
                speed * Time.deltaTime
            );

            // 抵達目標點判定
            if (Vector3.Distance(transform.position, targets[currentTargetIndex]) < 0.05f)
            {
                transform.position = targets[currentTargetIndex]; // 吸附對齊，杜絕抖動
                currentTargetIndex++;                             // 前往下一個陣列目標
            }
        }
        else
        {
            Debug.Log("已成功完成：往前走 -> 上跳越過障礙物 -> 下跳著陸 -> 往前走到終點！");
        }
    }
}