using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;//���浱ǰcube���ϵ���̨
    public GameObject buildEffect;
    public GameObject UpgradeEffect;
    [HideInInspector]//����ʾ�������
    public bool isUpgraded = false;//��������

    [HideInInspector]
    public TurretData turretData;



    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void OnMouseEnter()
    {

        if (turretGo == null && EventSystem.current.IsPointerOverGameObject() == false)
        {
            renderer.material.color = Color.red;
        }
    }
    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    public float yOffset = 1f; // ��������������Inspector�н��е���

    public void UpgradeTurret()
    {
        if (isUpgraded == true) return;

        Destroy(turretGo);
        isUpgraded = true;
        Vector3 newPosition = transform.position + new Vector3(0f, yOffset, 0f);
        turretGo = GameObject.Instantiate(turretData.turretUpgradedPrefab, newPosition, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(UpgradeEffect, newPosition, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    public void DestroyTurret()
    {
        Destroy(turretGo);
        isUpgraded = false;
        turretGo = null;
        turretData = null;
        GameObject effect = GameObject.Instantiate(UpgradeEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    public void BuildTurret(TurretData turretData)
    {
        this.turretData = turretData;
        isUpgraded = false;
        Vector3 newPosition = transform.position + new Vector3(0f, yOffset, 0f);
        turretGo = GameObject.Instantiate(turretData.turretPrefab, newPosition, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, newPosition, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

}
