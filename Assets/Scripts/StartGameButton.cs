using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine(FindPlayer());

    }

    IEnumerator FindPlayer()
    {

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync("SpaceInvadersGame");

        while (!asyncOp.isDone)
        {
            yield return null;

        }

    }
}
