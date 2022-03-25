using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerLive;
    public float playerSpeed;

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

    private void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Enemy")
        {
            playerLive = playerLive - EnemyController.enemyDamage;
        }
    }
}
