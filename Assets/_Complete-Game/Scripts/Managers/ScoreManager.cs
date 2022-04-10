using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;        // The player's score.
        int waveNum;
        float zenTime;
        string gameMode;

        Text text;                      // Reference to the Text component.


        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();
            gameMode = EnemyManager.gameMode;


            // Reset the score.
            score = 0;
        }


        void Update ()
        {
            if (gameMode == "zen")
            {
                zenTime = EnemyManager.zenTime;
                // Set the displayed text to be the word "Score" followed by the score value.
                text.text = "Time: " + zenTime.ToString("0.00");
            }
            else
            {
                waveNum = EnemyManager.waveNum;
                // Set the displayed text to be the word "Score" followed by the score value.
                text.text = "Wave " + waveNum + " - Score: " + score;
            }
        }
    }
}