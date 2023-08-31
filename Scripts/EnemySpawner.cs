using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int CountEnemyAlive = 0;
    public Wave[] waves;
    public Transform START;
    public float waveRate = 0.5f;
    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    public void Stop()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator SpawnEnemy()
    {
        foreach (Wave wave in waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, START.position, Quaternion.identity);
                yield return new WaitForSeconds(wave.rate);
                CountEnemyAlive++;
                if (i != wave.count - 1)
                    yield return new WaitForSeconds(wave.rate);
            }
            while (CountEnemyAlive > 0)
            {
                yield return 0;
            }
        }
        while (CountEnemyAlive > 0)
        {
            yield return 0;
        }
        GameManager.Instance.Win();
    }
}
