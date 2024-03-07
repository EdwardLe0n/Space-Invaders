using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    // Score variables that hod the currenty and the highest score
    private int currentScore = 0;
    private int hiScore = 0;

    // TMP References to the UI
    public TextMeshProUGUI currScoreText;
    public TextMeshProUGUI hiScoreText;

    // Start is called before the first frame update
    void Start()
    {

        // Subscribes the game manager to the OnEnemyDied Finction
        Enemy.OnEnemyDied += EnemyOnEnemyDied;

        // Gets the value stored in player prefs and puts it in hiScore
        hiScore = Getint("hiScore");

        // If the value is null, it will set hiScore to 0
        if (hiScore == null)
        {

            hiScore = 0;

        }
    }

    // Update is called once per frame
    void Update()
    {

        // String w/ leading 0s that gets used by the UI elements
        string lead = "0000.##";

        // Updates the current score text in a variable and then sets it
        string currScoreStr = $"SCORE\n{currentScore.ToString(lead)}";
        currScoreText.text = currScoreStr;

        // Updates the high score text in a variable and then sets it
        string hiScoreStr = $"HI-SCORE\n  {hiScore.ToString(lead)}";
        hiScoreText.text = hiScoreStr;


    }

    void EnemyOnEnemyDied(int pointsWorth)
    {
        // Sanity check
        Debug.Log("Player got a total of " + pointsWorth + " points.");

        // When an enemy dies, it will update the current sessions total points
        currentScore += pointsWorth;

        // If the current score is larger than the high score, it will update the high score
        if (hiScore < currentScore)
        {
            SetInt("hiScore", currentScore);
        }

    }

    // Will return the high score from the play sessions
    public int Getint(string keyname)
    {
        return PlayerPrefs.GetInt(keyname);
    }

    // Sets the hi score into player prefs and to the local variable
    public void SetInt(string keyname, int value)
    {
        PlayerPrefs.SetInt(keyname, value);
        hiScore = value;
    }

}
