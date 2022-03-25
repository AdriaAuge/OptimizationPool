using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerLive;
    public float playerSpeed;
    public Transform bulletOrigin;

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
        if(Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = BulletsPooling.Instance.RequestPlayerBullets();
            
            bullet.transform.position = new Vector3(bulletOrigin.transform.position.x, bulletOrigin.transform.position.y, bulletOrigin.transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Enemy")
        {
            playerLive = playerLive - EnemyController.enemyDamage;
        }
    }
}
