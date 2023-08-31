using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float targetRotationY = 0.0f; // 目标旋转角度
    private float rotationSpeed = 180.0f; // 旋转速度，可根据需要调整

    private bool isRotating = false;

    private void Update()
    {
        if (isRotating)
        {
            // 计算当前旋转角度
            float currentRotationY = transform.eulerAngles.y;
            Vector3 currentRotation = transform.eulerAngles;
            // 渐变地改变旋转角度
            float step = rotationSpeed * Time.deltaTime;
            float newRotationY = Mathf.MoveTowardsAngle(currentRotationY, targetRotationY, step);

            // 更新摄像机的旋转
            transform.rotation = Quaternion.Euler(currentRotation.x, newRotationY, currentRotation.z);

            // 检查是否完成旋转
            if (Mathf.Approximately(newRotationY, targetRotationY))
            {
                isRotating = false;
            }
        }
    }

    public void RotateCamera()
    {
        if (!isRotating)
        {
            // 设置目标旋转角度为当前角度加180度
            targetRotationY = transform.eulerAngles.y + 180.0f;

            // 启动渐变旋转
            isRotating = true;
        }
    }
}
