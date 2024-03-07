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
    public float heightMod = 3f;

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
        
        GameObject enem;

        for (int i = 0; i <= 5; i++ ){
            enem = Instantiate(enemA, new Vector3(2f * i - 5f, 1f + heightMod, 1f), Quaternion.identity, this.transform);
            enem.name = "enemA" + i;
            enem = Instantiate(enemB, new Vector3(2f * i - 5f, 0f + heightMod, 1f), Quaternion.identity, this.transform);
            enem.name = "enemB" + i;
            enem = Instantiate(enemC, new Vector3(2f * i - 5f,-1f + heightMod, 1f), Quaternion.identity, this.transform);
            enem.name = "enemC" + i;
        }

    }

}
