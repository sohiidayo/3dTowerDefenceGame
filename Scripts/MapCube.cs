using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;//保存当前cube身上的炮台
    public GameObject buildEffect;


    public void BuildTurret(TurretData turretData) 
    {
        turretGo = GameObject.Instantiate(turretData.turretPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

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
}
