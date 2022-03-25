using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPooling : MonoBehaviour
{
    public int playerPoolSize;
    public GameObject playerBulletPrebaf;
    public Transform playerBulletZone;
    public Transform playerBulletParent;
    public List<GameObject> playerBulletsList;

    private static BulletsPooling instance;
    private static BulletsPooling Instance { get { return instance; } }

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
            GameObject playerBullet = Instantiate(playerBulletPrebaf, playerBulletZone);
            playerBullet.SetActive(false);
            playerBulletsList.Add(playerBullet);
            playerBullet.transform.parent = playerBulletParent;
        }
    }

    private GameObject RequestPlayerBullets()
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
