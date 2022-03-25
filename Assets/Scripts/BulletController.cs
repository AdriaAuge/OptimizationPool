using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletType;            //Player = 0    //Enemy = 1
    
    private Vector3 bulletDirection;

    private void OnEnable()
    {
        if(bulletType == 0)
        {
            bulletDirection = new Vector3(0, 0, 1);
        }
        if(bulletType == 1)
        {
            bulletDirection = new Vector3(0, 0, -1);
        }
        
        gameObject.GetComponent<Rigidbody>().AddForce(bulletDirection * Time.deltaTime * bulletSpeed);
    }

    private void OnCollisionEnter()
    {
        gameObject.SetActive(false);
    }
}
