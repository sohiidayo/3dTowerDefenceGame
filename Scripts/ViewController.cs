using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    [Header("移动")]
    public float initialSpeed = 0;
    public float maxSpeed = 35;
    public float acceleration = 7.5f;
    [Header("旋转")]
    public float initialRotationSpeed = 50;
    public float maxRotationSpeed = 200;
    public float rotationAcceleration = 10;
    [Header("缩放")]
    public float scrollSpeed = 10f;

    private float currentSpeed; // 当前移动速度
    private float currentRotationSpeed; // 当前旋转速度

    void Start()
    {
        currentSpeed = initialSpeed; // 初始化当前移动速度
        currentRotationSpeed = initialRotationSpeed; // 初始化当前旋转速度
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // 获取水平输入
        float v = Input.GetAxis("Vertical"); // 获取垂直输入
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel"); // 获取鼠标滚轮输入

        float rotateDirection = 0f;
        if (Input.GetKey(KeyCode.Q)) // 检测是否按下Q键
        {
            rotateDirection = -1f; // 逆时针旋转
        }
        else if (Input.GetKey(KeyCode.E)) // 检测是否按下E键
        {
            rotateDirection = 1f; // 顺时针旋转
        }

        Vector3 movement = new Vector3(h * currentSpeed, 0, v * currentSpeed); // 移动向量，不包含垂直方向
        movement *= Time.deltaTime; // 根据时间增量平滑移动

        Vector3 cameraForward = transform.forward;
        cameraForward.y = 0;

        movement = transform.TransformDirection(movement); // 转换为局部坐标系的移动向量
        movement.y = 0; // 保持在水平平面上移动

        transform.Translate(movement, Space.World); // 在世界坐标系中进行平移变换

        Vector3 rotation = transform.rotation.eulerAngles; // 获取当前旋转角度
        rotation.y += rotateDirection * Time.deltaTime * currentRotationSpeed; // 根据输入旋转
        transform.rotation = Quaternion.Euler(rotation); // 进行旋转变换

        transform.Translate(Vector3.forward * mouseScroll * scrollSpeed, Space.Self); // 使用鼠标滚轮移动摄像机

        // 根据加速度更新当前移动速度，限制在初始速度和最大速度之间
        currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, initialSpeed, maxSpeed);

        // 根据旋转加速度更新当前旋转速度，限制在初始速度和最大速度之间
        currentRotationSpeed = Mathf.Clamp(currentRotationSpeed + rotationAcceleration * Time.deltaTime, initialRotationSpeed, maxRotationSpeed);
    }
}
