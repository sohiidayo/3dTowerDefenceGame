using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WayPoints : MonoBehaviour
{
    // �洢·����λ�õ�����
    public static Transform[] positions;

    // ����Ϸ���󱻴���ʱִ�г�ʼ������
    void Awake()
    {
        // ��ȡ��ǰ��Ϸ������Ӷ�������������ȷ�������С
        int childCount = transform.childCount;
        // ����һ�����Ӷ���������ͬ��С�����飬���ڴ洢·����� Transform ���
        positions = new Transform[childCount];
        // �����Ӷ��󣬽�ÿ���Ӷ���� Transform ����洢��������
        for (int i = 0; i < childCount; i++)
        {
            positions[i] = transform.GetChild(i);
        }
    }
}