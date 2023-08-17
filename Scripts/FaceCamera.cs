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
        // 获取摄像头的正前方向
        Vector3 cameraForward = mainCameraTransform.forward;

        // 将Y轴旋转归零，使UI保持水平
        cameraForward.y = 0.0f;

        // 将UI的正前方向设置为摄像头的水平方向
        transform.forward = cameraForward;
    }
}
