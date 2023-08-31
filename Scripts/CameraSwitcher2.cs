using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher2 : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    private void Start()
    {
        // ��ʼʱ�����һ������ͷ��������������ͷ
        ActivateCamera(currentCameraIndex);
    }

    public void SwitchToPreviousCamera()
    {
        // �л�����һ������ͷ
        currentCameraIndex = (currentCameraIndex - 1 + cameras.Length) % cameras.Length;
        ActivateCamera(currentCameraIndex);
    }

    public void SwitchToNextCamera()
    {
        // �л�����һ������ͷ
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
        ActivateCamera(currentCameraIndex);
    }

    public void SwitchToFirstCamera()
    {
        // �л�����һ������ͷ
        currentCameraIndex = 0;
        ActivateCamera(currentCameraIndex);
    }

    private void ActivateCamera(int index)
    {
        // ����ָ������ͷ��������������ͷ
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }
    }
}
