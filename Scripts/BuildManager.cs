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
    //表示当前选择的炮台(要建造的炮台)
    private TurretData selectedTurretData;
    //表示当前选择的炮台(场景中的游戏物体)
    private MapCube selectedMapCube;

    private int money = 1000;
    public TextMeshProUGUI moneyText;

    public Animator moneyAnimator;


    public GameObject upgradeCanvas;
    public Button buttonUpgrade;

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
            //点击到UI上不做处理
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
                        //可以创建 
                        if (money > selectedTurretData.cost)
                        {
                            mapCube.BuildTurret(selectedTurretData);
                            ChangeMoney(-selectedTurretData.cost);
                            
                        }
                        else
                        {
                            //提示钱不够
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }
                    else if (mapCube.turretGo !=null)
                    {
                        // 升级处理
                        ShowUpgradeUI(mapCube.transform.position,mapCube.isUpgraded);
                        if (mapCube == selectedMapCube && upgradeCanvas.activeInHierarchy)
                        {
                            HideUpgradeUI();
                        }
                        else
                        {
                            ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgraded);
                        }
                        selectedMapCube = mapCube;
                    }
                }

            }
        }
    }
    void ShowUpgradeUI(Vector3 pos, bool isDisableUpgrade = false)
    {
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        buttonUpgrade.interactable = !isDisableUpgrade;
    }
    void HideUpgradeUI()
    {
        upgradeCanvas.SetActive(false);
    }

    public void OnUpgradeButtonDown()
    {

    }
    public void OnDestroyButtonDown()
    {

    }
}
