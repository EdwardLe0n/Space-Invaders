using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform shottingOffset;
    public float pSpeed = 100f;
    public bool canShoot = true;
    public bool firstFired = false;
    public int lives = 1;

    public delegate void PlayerState();
    public static event PlayerState FirstShot;
    public static event PlayerState Died;

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        // Subscribes itslef to see when the bullet gets destroyed
        Bullet.OnBulletDestroy += BulletDestroyed;

    }

    private void OnDestroy()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("SpaceInvadersMenu"))
            Died.Invoke();
        Bullet.OnBulletDestroy -= BulletDestroyed;

    }

    void BulletDestroyed()
    {
        //Debug.Log("Bullet has been destroyed");
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            //Debug.Log(firstFired);
            //GetComponent<Animator>().SetTrigger("Shoot Trigger");

            // If this is the first time a player has shot this game, then
            // It will send out a message so that some UI elements will
            // then get deleted
            if (!firstFired)
            {
                firstFired = true;
                FirstShot.Invoke();
                //Debug.Log("Got to ptA");
            }

            // If the game isn't in the menu scene, then an actual bullet will get fired!

            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("SpaceInvadersMenu"))
            {

                anim.SetTrigger("shot");

                GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);

                canShoot = false;
                Destroy(shot, 1.2f);
            }
            // Debug.Log("Bang!");

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            tookDamage();
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

    // Will only run when the player loses a life
    void tookDamage()
    {

        lives--;

        if (lives <= 0)
        {
            anim.SetTrigger("died");

            Destroy(gameObject, 1f);
        }

    }


}
 
