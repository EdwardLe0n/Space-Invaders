using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int points = 3;
    public delegate void EnemyDied(int pointsWorth);
    public static event EnemyDied OnEnemyDied;
    private bool dead = false;
    public int health = 1;

    void Start()
    {



    }

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Sanity check
        // Debug.Log("Ouch!");

        // When the enemy get's hit, it first destroys the bullet and decreases it's health by 1

        Destroy(collision.gameObject);
        health--;

        // If the health of the enemy is or is less than 0, then it will die and give it's appropriate animation

        // The reason for the dead variable is so that the enemies can't be 'milked' for points

        if (health <= 0 && !dead)
        {

            // Sets the dead bool to true
            dead = true;

            // Lets other systems in the game know that this enemy has died, and will then destroy itself
            OnEnemyDied.Invoke(points);
            Destroy(gameObject, 1f);

            // GetComponent<Animator>().SetTrigger("enemyDeath");

        }

    }
}
