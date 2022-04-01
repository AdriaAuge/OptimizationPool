using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemyLive;
    public static int enemyDamage = 10;
    public float shootTime;
    public bool canShoot;

    [Header("ENEMY POOLING")]
    public int enemyPoolSize;
    public GameObject enemyBulletPrebaf;
    public Transform enemyBulletOrigin;
    public List<GameObject> enemyBulletsList;

    private void Start()
    {
        AddEnemyBulletsToPool(enemyPoolSize);

        canShoot = true;
    }

    private void AddEnemyBulletsToPool(int amount)
    {
        for(int b = 0; b < amount; b++)
        {
            GameObject enemyBullet = Instantiate(enemyBulletPrebaf);
            enemyBullet.SetActive(false);
            enemyBulletsList.Add(enemyBullet);
            enemyBullet.transform.parent = enemyBulletOrigin;
        }
    }

    private GameObject RequestEnemyBullets()
    {
        for(int b = 0; b < enemyBulletsList.Count; b++)
        {
            if(!enemyBulletsList[b].activeSelf)
            {
                enemyBulletsList[b].SetActive(true);
                return enemyBulletsList[b];
            }
        }
        return null;
    }

    private void Update()
    {
        if(canShoot == true)
        {
            canShoot = false;
            
            GameObject bullet = RequestEnemyBullets();           
            bullet.transform.position = new Vector3(enemyBulletOrigin.transform.position.x, enemyBulletOrigin.transform.position.y, enemyBulletOrigin.transform.position.z);

            StartCoroutine("ShootTiming");
        }

        if(enemyLive <= 0)
        {
            DestroyedEnemy();
        }
    }

    private IEnumerator ShootTiming()
    {
        yield return new WaitForSeconds(shootTime);
        canShoot = true;
    }

    private void OnCollisionEnter(Collision bullet)
    {
        if(bullet.gameObject.tag == "PlayerBullets")
        {
            enemyLive = enemyLive - PlayerController.playerDamage;
        }
    }

    private void DestroyedEnemy()
    {
        this.gameObject.SetActive(false);
    }
}
