using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float targetRotationY = 0.0f; // Ŀ����ת�Ƕ�
    private float rotationSpeed = 180.0f; // ��ת�ٶȣ��ɸ�����Ҫ����

    private bool isRotating = false;

    private void Update()
    {
        if (isRotating)
        {
            // ���㵱ǰ��ת�Ƕ�
            float currentRotationY = transform.eulerAngles.y;
            Vector3 currentRotation = transform.eulerAngles;
            // ����ظı���ת�Ƕ�
            float step = rotationSpeed * Time.deltaTime;
            float newRotationY = Mathf.MoveTowardsAngle(currentRotationY, targetRotationY, step);

            // �������������ת
            transform.rotation = Quaternion.Euler(currentRotation.x, newRotationY, currentRotation.z);

            // ����Ƿ������ת
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
            // ����Ŀ����ת�Ƕ�Ϊ��ǰ�Ƕȼ�180��
            targetRotationY = transform.eulerAngles.y + 180.0f;

            // ����������ת
            isRotating = true;
        }
    }
}
