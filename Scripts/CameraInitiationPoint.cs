using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitiationPoint : MonoBehaviour
{
    [Header("��ʼ�����")]
    public Transform targetPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            MoveAndOrientToTarget();
        }
    }

    private void MoveAndOrientToTarget()
    {
        transform.position = targetPosition.position;
        transform.rotation = targetPosition.rotation;
    }
}
