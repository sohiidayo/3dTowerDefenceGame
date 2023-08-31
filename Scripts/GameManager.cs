using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject endUI;
    public TextMeshProUGUI endMessage;

    public static GameManager Instance;
    private EnemySpawner enemySpawner;
    void Awake()
    {
        Instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
    }

    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "Win";
    }
    public void Failed()
    {
        endUI.SetActive(true);
        endMessage.text = "Failed";
    }

    public void OnButtonRetry()//ÖØÍæ
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnButtonMenu()//²Ëµ¥
    {
        SceneManager.LoadScene(0);
    }
}
