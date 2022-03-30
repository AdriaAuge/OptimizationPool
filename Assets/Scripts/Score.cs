using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int actualScore;
    public static int maxScore;
    public static int enemyPoints = 10;
    
    private void Start()
    {
        actualScore = 0;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            Debug.Log(actualScore);
        }
    }
}
