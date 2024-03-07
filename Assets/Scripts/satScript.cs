using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple script that destroys the table when the player fires the first shot

public class satScript : MonoBehaviour
{
    public delegate void initUI();
    public static event initUI GotDestroyed;

    void Start()
    {
        Player.FirstShot += FirstShotFired;
    }

    private void OnDestroy()
    {

        Player.FirstShot -= FirstShotFired;

    }

    void FirstShotFired()
    {
        //Debug.Log("Got to ptB");
        GotDestroyed.Invoke();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
