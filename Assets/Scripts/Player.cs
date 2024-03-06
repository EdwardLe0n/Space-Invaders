using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform shottingOffset;
    public float pSpeed = 100f;

    void Start()
    {

        Enemy.OnEnemyDied += EnemyOnEnemyDied;

    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDied -= EnemyOnEnemyDied;
    }

    void EnemyOnEnemyDied(int pointsWorth)
    {
        // Debug.Log("Player recieved enemy died");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //GetComponent<Animator>().SetTrigger("Shoot Trigger");

            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            // Debug.Log("Bang!");

            Destroy(shot, 3f);

        }

        // dealing w/ horizontal movement

        // Gets the horizontal input from the input manager
        float horizontalMovement = Input.GetAxis("Horizontal");

        // Gets the rigidbody component to mess with the velocity of the platyer later
        Rigidbody rbody = GetComponent<Rigidbody>();

        // Sets the player velocity to whatever is to the right of it times the horizontal movement as well 
        // as the amount of time passed, and by the plaer speed modifier;
        rbody.velocity = Vector3.right * horizontalMovement * Time.deltaTime * pSpeed;

    }
}
