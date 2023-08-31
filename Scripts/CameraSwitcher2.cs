using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher2 : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    private void Start()
    {
        // 开始时激活第一个摄像头，禁用其他摄像头
        ActivateCamera(currentCameraIndex);
    }

    public void SwitchToPreviousCamera()
    {
        // 切换到上一个摄像头
        currentCameraIndex = (currentCameraIndex - 1 + cameras.Length) % cameras.Length;
        ActivateCamera(currentCameraIndex);
    }

    public void SwitchToNextCamera()
    {
        // 切换到下一个摄像头
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
        ActivateCamera(currentCameraIndex);
    }

    public void SwitchToFirstCamera()
    {
        // 切换到第一个摄像头
        currentCameraIndex = 0;
        ActivateCamera(currentCameraIndex);
    }

    private void ActivateCamera(int index)
    {
        // 激活指定摄像头，禁用其他摄像头
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }
    }
}
