using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace CompleteProject
{
    public class GameOverMenu : MonoBehaviour
    {
        public InputField playerNameInput;
        public Text scoreText;
        public Text waveText;
        public Text timeText;
        public GameObject zenMenu;
        public GameObject waveMenu;
        [ContextMenu("Test")]
        void Awake(){
            Debug.Log(EnemyManager.gameMode);
            if(EnemyManager.gameMode == "zen"){
                zenMenu.SetActive(true);
                waveMenu.SetActive(false);
                // nameText.text = entryData.name;
                int hour = (int) EnemyManager.zenTime/3600;
                int remain = (int) EnemyManager.zenTime%3600;
                int minutes = remain/60;
                int seconds = remain%60;
                string time = "";
                if (hour > 0){
                    time += hour.ToString() + "h ";
                }
                if (minutes > 0){
                    time += minutes.ToString() + "m ";
                }
                if (seconds > 0){
                    time += seconds.ToString() + "s";
                }
                timeText.text = "Time: " + time;
                ScoreboardZen scoreboardZen = new ScoreboardZen();
                ScoreboardZenEntryData test =  new ScoreboardZenEntryData()
                    {
                        name = MainMenu.playerName,
                        time = (int) EnemyManager.zenTime
                    };
                Debug.Log(test.ToString());
                scoreboardZen.AddEntry(test);
            } else {
                waveMenu.SetActive(true);
                zenMenu.SetActive(false);
                
                waveText.text = "Wave: " + EnemyManager.waveNum;
                scoreText.text = "Score: " + ScoreManager.score;
                ScoreboardWave scoreboardWave = new ScoreboardWave();
                ScoreboardWaveEntryData test =  new ScoreboardWaveEntryData()
                    {
                    name = MainMenu.playerName,
                    wave = EnemyManager.waveNum,
                    score = ScoreManager.score
                    };
                Debug.Log(test.ToString());
                scoreboardWave.AddEntry(test);
            }
        }
        public void GoToMainMenu(){
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        
        public void SetZenMode(){
            EnemyManager.gameMode = "zen";
        }
        
        public void SetWaveMode(){
            EnemyManager.gameMode = "wave";
        }
        public void SetName(){
            MainMenu.playerName = playerNameInput.text;
            Debug.Log(MainMenu.playerName);
            Debug.Log(EnemyManager.gameMode);
            SceneManager.LoadScene("_Complete-Game", LoadSceneMode.Single);
        }

        public void BackButton(){
            if (EnemyManager.gameMode == "zen"){
                zenMenu.SetActive(true);
            }else{
                waveMenu.SetActive(true);
            }
        }
    }
}
