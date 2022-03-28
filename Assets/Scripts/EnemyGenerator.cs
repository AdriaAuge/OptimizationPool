using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float generationTime;
    public GameObject enemyPrefab;
    public Transform enemyParent;

    private void Start()
    {
        InvokeRepeating("EnemyGeneration", generationTime, generationTime);
    }

    private void EnemyGeneration()
    {
        var position = new Vector3(Random.Range(-50f, 480f), 0, Random.Range(200f, 240f));
        GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        
        enemy.transform.parent = enemyParent;
        enemy.transform.Rotate(new Vector3(-90, 0, 0));
    }

}
