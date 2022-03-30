using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("PLAYER STATS")]
    public int playerLive;
    public static int playerDamage = 50;
    public float playerSpeed;

    [Header("GAMEOBJECTS")]
    public Transform bulletOrigin;
    public GameObject gameOverPanel;
    public GameObject enemies;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");       
        rb.velocity = new Vector3(horizontal, 0, vertical) * Time.deltaTime * playerSpeed;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = BulletsPooling.Instance.RequestPlayerBullets();
            
            bullet.transform.position = new Vector3(bulletOrigin.transform.position.x, bulletOrigin.transform.position.y, bulletOrigin.transform.position.z);
        }

        if(playerLive <= 0)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Enemy")
        {
            playerLive = playerLive - EnemyController.enemyDamage;
        }
    }

    private void GameOver()
    {
        gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        enemies.SetActive(false);
    }
}
