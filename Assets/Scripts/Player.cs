using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;

    void Start()
    {

        Enemy.OnEnemyDied += EnemyOnEnemyDied;

    }

    void EnemyOnOnEnemyDided(int pointsWorth)
    {
        Debug.Log("Player recieved enemy died");
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
    }
}
