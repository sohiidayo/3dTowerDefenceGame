using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstCamera;
    public Camera secondCamera;

    private void Start()
    {
        // ��ʼʱ�����õ�һ������������õڶ��������
        firstCamera.enabled = true;
        secondCamera.enabled = false;
    }

    public void SwitchCamera()
    {
        // �л������״̬
        firstCamera.enabled = !firstCamera.enabled;
        secondCamera.enabled = !secondCamera.enabled;
    }
}
