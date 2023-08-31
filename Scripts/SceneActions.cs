using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneActions : MonoBehaviour
{
    public void SwitchToLevel1()
    {
        SceneManager.LoadScene("LEVEL1");
    }

    public void SwitchToLevel2()
    {
        SceneManager.LoadScene("LEVEL2");
    }

    public void SwitchToLevel3()
    {
        SceneManager.LoadScene("LEVEL3");
    }

    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Debug.Log("ÓÎÏ·¼´½«ÍË³ö");
        Application.Quit();
    }
}



