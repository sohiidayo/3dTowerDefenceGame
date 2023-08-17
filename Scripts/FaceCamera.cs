using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        // ��ȡ����ͷ����ǰ����
        Vector3 cameraForward = mainCameraTransform.forward;

        // ��Y����ת���㣬ʹUI����ˮƽ
        cameraForward.y = 0.0f;

        // ��UI����ǰ��������Ϊ����ͷ��ˮƽ����
        transform.forward = cameraForward;
    }
}
