using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("ENEMY STATS")]
    public int enemyLive;
    private int enemyOriginalLive;
    public static int enemyDamage = 10;
    public float enemySpeed;
    public float shootTime;
    public bool canShoot;

    [Header("ENEMY POOLING")]
    public int enemyPoolSize;
    public GameObject enemyBulletPrebaf;
    public Transform enemyBulletOrigin;
    public List<GameObject> enemyBulletsList;

    private Rigidbody enemyRb;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        AddEnemyBulletsToPool(enemyPoolSize);

        enemyOriginalLive = enemyLive;
        canShoot = true;

        InvokeRepeating("Shooting", 0.01f, shootTime);
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

    private void Shooting()
    {
        GameObject bullet = RequestEnemyBullets();           
        bullet.transform.position = new Vector3(enemyBulletOrigin.transform.position.x, enemyBulletOrigin.transform.position.y, enemyBulletOrigin.transform.position.z);
    }

    private void Update()
    {
        if(enemyLive <= 0)
        {
            DestroyedEnemy();
        }
    }

    private void FixedUpdate()
    {
        enemyRb.velocity = new Vector3(0, 0, -enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.tag == "PlayerBullets")
        {
            enemyLive = enemyLive - PlayerController.playerTotalDamage;
        }
        else if(collider.gameObject.tag == "Wall")
        {
            DestroyedEnemy();
        }
    }

    private void DestroyedEnemy()
    {
        this.gameObject.SetActive(false);
        enemyLive = enemyOriginalLive;
    }
}
