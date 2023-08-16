using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;
    //��ʾ��ǰѡ�����̨(Ҫ�������̨)
    private TurretData selectedTurretData;

    private int money = 1000;
    public TextMeshProUGUI moneyText;

        public Animator moneyAnimator;

    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = laserTurretData;
        }
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = missileTurretData;
        }
    }
    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurretData = standardTurretData;
        }
    }
    public void ChangeMoney(int change = 0)
    {
        money += change;
        moneyText.text = "$" + money;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //�����UI�ϲ�������
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    if (selectedTurretData != null && mapCube.turretGo == null)
                    {
                        //���Դ��� 
                        if (money > selectedTurretData.cost)
                        {
                            mapCube.BuildTurret(selectedTurretData);
                            ChangeMoney(-selectedTurretData.cost);
                            
                        }
                        else
                        {
                            //��ʾǮ����
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }
                    else if (mapCube.turretGo !=null)
                    {
                    
                        
                    }
                }

            }
        }
    }
}