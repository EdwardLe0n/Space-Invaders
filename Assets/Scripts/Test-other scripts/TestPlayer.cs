using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;

    void Start()
    {

        Enemy.OnEnemyDied += EnemyOnOnEnemyDied;

    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
    }

    void EnemyOnOnEnemyDied(int pointsWorth)
    {
        Debug.Log("Player recieved enemy died");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            GetComponent<Animator>().SetTrigger("Shoot Trigger");

            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");

            Destroy(shot, 3f);

        }
    }
}
