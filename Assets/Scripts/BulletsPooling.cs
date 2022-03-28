using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPooling : MonoBehaviour
{
    [Header("BULLETS POOL")]
    public int playerPoolSize;
    public GameObject playerBulletPrefab;
    public Transform playerBulletParent;
    public List<GameObject> playerBulletsList;

    private static BulletsPooling instance;
    public static BulletsPooling Instance { get { return instance; } }

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
        AddPlayerBulletsToPool(playerPoolSize);
    }

    private void AddPlayerBulletsToPool(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject playerBullet = Instantiate(playerBulletPrefab);
            playerBullet.SetActive(false);
            playerBulletsList.Add(playerBullet);
            playerBullet.transform.parent = playerBulletParent;
        }
    }

    public GameObject RequestPlayerBullets()
    {
        for(int i = 0; i < playerBulletsList.Count; i++)
        {
            if(!playerBulletsList[i].activeSelf)
            {
                playerBulletsList[i].SetActive(true);
                return playerBulletsList[i];
            }
        }
        return null;
    }
}
