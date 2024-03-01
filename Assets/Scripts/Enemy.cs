﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int points = 3;
    public delegate void EnemyDied(int pointsWorth);
    public static event EnemyDied OnEnemyDied;

    void Start()
    {



    }

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
        Destroy(collision.gameObject);

        OnEnemyDied.Invoke(collision);
        Destroy(gameObject);
    }
}
