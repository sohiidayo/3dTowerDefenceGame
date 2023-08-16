using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WayPoints : MonoBehaviour
{
    // 存储路径点位置的数组
    public static Transform[] positions;

    // 在游戏对象被创建时执行初始化操作
    void Awake()
    {
        // 获取当前游戏对象的子对象数量，用于确定数组大小
        int childCount = transform.childCount;
        // 创建一个与子对象数量相同大小的数组，用于存储路径点的 Transform 组件
        positions = new Transform[childCount];
        // 遍历子对象，将每个子对象的 Transform 组件存储到数组中
        for (int i = 0; i < childCount; i++)
        {
            positions[i] = transform.GetChild(i);
        }
    }
}