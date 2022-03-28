using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletType;            //Player = 0    //Enemy = 1   
    private int bulletDirection;

    private void Start()
    {
        if(bulletType == 0)
        {
            bulletDirection = 1;
        }
        if(bulletType == 1)
        {
            bulletDirection = -1;
        }
    }

    private void FixedUpdate()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletDirection) * Time.deltaTime * bulletSpeed;
    }

    private void OnCollisionEnter()
    {
        this.gameObject.SetActive(false);
    }
}
