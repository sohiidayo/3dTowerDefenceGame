using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    [Header("�ƶ�")]
    public float initialSpeed = 0;
    public float maxSpeed = 35;
    public float acceleration = 7.5f;
    [Header("��ת")]
    public float initialRotationSpeed = 50;
    public float maxRotationSpeed = 200;
    public float rotationAcceleration = 10;
    [Header("����")]
    public float scrollSpeed = 10f;

    private float currentSpeed; // ��ǰ�ƶ��ٶ�
    private float currentRotationSpeed; // ��ǰ��ת�ٶ�

    void Start()
    {
        currentSpeed = initialSpeed; // ��ʼ����ǰ�ƶ��ٶ�
        currentRotationSpeed = initialRotationSpeed; // ��ʼ����ǰ��ת�ٶ�
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // ��ȡˮƽ����
        float v = Input.GetAxis("Vertical"); // ��ȡ��ֱ����
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel"); // ��ȡ����������

        float rotateDirection = 0f;
        if (Input.GetKey(KeyCode.Q)) // ����Ƿ���Q��
        {
            rotateDirection = -1f; // ��ʱ����ת
        }
        else if (Input.GetKey(KeyCode.E)) // ����Ƿ���E��
        {
            rotateDirection = 1f; // ˳ʱ����ת
        }

        Vector3 movement = new Vector3(h * currentSpeed, 0, v * currentSpeed); // �ƶ���������������ֱ����
        movement *= Time.deltaTime; // ����ʱ������ƽ���ƶ�

        Vector3 cameraForward = transform.forward;
        cameraForward.y = 0;

        movement = transform.TransformDirection(movement); // ת��Ϊ�ֲ�����ϵ���ƶ�����
        movement.y = 0; // ������ˮƽƽ�����ƶ�

        transform.Translate(movement, Space.World); // ����������ϵ�н���ƽ�Ʊ任

        Vector3 rotation = transform.rotation.eulerAngles; // ��ȡ��ǰ��ת�Ƕ�
        rotation.y += rotateDirection * Time.deltaTime * currentRotationSpeed; // ����������ת
        transform.rotation = Quaternion.Euler(rotation); // ������ת�任

        transform.Translate(Vector3.forward * mouseScroll * scrollSpeed, Space.Self); // ʹ���������ƶ������

        // ���ݼ��ٶȸ��µ�ǰ�ƶ��ٶȣ������ڳ�ʼ�ٶȺ�����ٶ�֮��
        currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, initialSpeed, maxSpeed);

        // ������ת���ٶȸ��µ�ǰ��ת�ٶȣ������ڳ�ʼ�ٶȺ�����ٶ�֮��
        currentRotationSpeed = Mathf.Clamp(currentRotationSpeed + rotationAcceleration * Time.deltaTime, initialRotationSpeed, maxRotationSpeed);
    }
}
