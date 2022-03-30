using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("ENEMIES POOL")]
    public int enemyPoolSize;
    public float generationTime;
    public GameObject enemyPrefab;
    public Transform enemyParent;
    public List<GameObject> enemyList;

    private static EnemyGenerator instance;
    public static EnemyGenerator Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AddEnemiesToPool(enemyPoolSize);
        InvokeRepeating("Generation", generationTime, generationTime);
    }

    private void AddEnemiesToPool(int amount)
    {
        for(int e = 0; e < amount; e++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyList.Add(enemy);
            enemy.transform.parent = enemyParent;
        }
    }

    public GameObject RequestEnemies()
    {
        for(int e = 0; e < enemyList.Count; e++)
        {
            if(!enemyList[e].activeSelf)
            {
                enemyList[e].SetActive(true);
                return enemyList[e];
            }
        }
        return null;
    }

    private void Generation()
    {
        GameObject _enemy = EnemyGenerator.Instance.RequestEnemies();

        _enemy.transform.position = new Vector3(Random.Range(-50, 475), 0, Random.Range(200, 240));
    }
}
