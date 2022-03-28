using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static float enemyDamage;
    public float shootTime;
    public bool canShoot;

    [Header("ENEMY POOLING")]
    public int enemyPoolSize;
    public GameObject enemyBulletPrebaf;
    public Transform enemyBulletOrigin;
    public List<GameObject> enemyBulletsList;

    private static EnemyController instance;
    public static EnemyController Instance { get { return instance; } }

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
        AddEnemyBulletsToPool(enemyPoolSize);

        canShoot = true;
    }

    private void AddEnemyBulletsToPool(int amount)
    {
        for(int e = 0; e < amount; e++)
        {
            GameObject enemyBullet = Instantiate(enemyBulletPrebaf);
            enemyBullet.SetActive(false);
            enemyBulletsList.Add(enemyBullet);
            enemyBullet.transform.parent = enemyBulletOrigin;
        }
    }

    private GameObject RequestEnemyBullets()
    {
        for(int i = 0; i < enemyBulletsList.Count; i++)
        {
            if(!enemyBulletsList[i].activeSelf)
            {
                enemyBulletsList[i].SetActive(true);
                return enemyBulletsList[i];
            }
        }
        return null;
    }

    private void Update()
    {
        if(canShoot == true)
        {
            canShoot = false;
            
            GameObject bullet = EnemyController.Instance.RequestEnemyBullets();           
            bullet.transform.position = new Vector3(enemyBulletOrigin.transform.position.x, enemyBulletOrigin.transform.position.y, enemyBulletOrigin.transform.position.z);

            StartCoroutine("ShootTiming");
        }
    }

    private IEnumerator ShootTiming()
    {
        yield return new WaitForSeconds(shootTime);
        canShoot = true;
    }
}
