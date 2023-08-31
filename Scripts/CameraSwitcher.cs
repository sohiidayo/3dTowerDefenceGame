using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstCamera;
    public Camera secondCamera;

    private void Start()
    {
        // 开始时，启用第一个摄像机，禁用第二个摄像机
        firstCamera.enabled = true;
        secondCamera.enabled = false;
    }

    public void SwitchCamera()
    {
        // 切换摄像机状态
        firstCamera.enabled = !firstCamera.enabled;
        secondCamera.enabled = !secondCamera.enabled;
    }
}
