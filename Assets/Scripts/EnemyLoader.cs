using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoader : MonoBehaviour
{

    public delegate void EnemyManager(float enemyFraction);
    public static event EnemyManager CheckUp;
    public static event EnemyManager Fire;

    public GameObject enemA;
    public GameObject enemB;
    public GameObject enemC;

    public int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribes the enemy loader to the destruction of the satScript
        satScript.GotDestroyed += LoadEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadEnemies()
    {
        Instantiate(enemA, new Vector3(1f, 1f, 1f), Quaternion.identity);
        Debug.Log("Pog");

    }

}
