﻿using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class ScoreboardZen : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform highscoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        private string SavePath => $"{Application.persistentDataPath}/zen_highscore.json";

        private void Start()
        {
            ScoreboardZenSaveData savedScores = GetSavedScores();
            
            UpdateUI(savedScores);

            SaveScores(savedScores);
        }

        public void AddEntry(ScoreboardZenEntryData scoreboardEntryData)
        {
            ScoreboardZenSaveData savedScores = GetSavedScores();
            bool scoreAdded = false;

            for (int i = 0; i < savedScores.highScores.Count; i++)
            {
                if (scoreboardEntryData.time > savedScores.highScores[i].time)
                {
                    savedScores.highScores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            if (!scoreAdded && savedScores.highScores.Count < maxScoreboardEntries)
            {
                savedScores.highScores.Add(scoreboardEntryData);
            }

            if (savedScores.highScores.Count > maxScoreboardEntries)
            {
                savedScores.highScores.RemoveRange(maxScoreboardEntries, savedScores.highScores.Count - maxScoreboardEntries);
            }

            SaveScores(savedScores);
        }

        [ContextMenu("Remove Entry")]
        public void RemoveEntry(){
            ScoreboardZenSaveData savedScores = GetSavedScores();
            savedScores.highScores.RemoveRange(0, savedScores.highScores.Count);
            SaveScores(savedScores);
        }

        private void UpdateUI(ScoreboardZenSaveData savedScores)
        {
            foreach (Transform child in highscoresHolderTransform)
            {
                Destroy(child.gameObject);
            }

            foreach (ScoreboardZenEntryData highscore in savedScores.highScores)
            {
                Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<ScoreboardZenEntryUI>().Initialise(highscore);
            }
        }

        private ScoreboardZenSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardZenSaveData();
            }

            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreboardZenSaveData>(json);
            }
        }

        private void SaveScores(ScoreboardZenSaveData scoreboardSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json);
            }
        }
    }
}