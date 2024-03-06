using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Subscribes the game manager to the OnEnemyDied Finction
        Enemy.OnEnemyDied += EnemyOnEnemyDied;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyOnEnemyDied(int pointsWorth)
    {
        Debug.Log("Player got a total of " + pointsWorth + " points.");
    }

    private void OnDestroy()
    {
        
    }

}
