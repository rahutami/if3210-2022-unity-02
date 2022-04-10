using System.IO;
using UnityEngine;

namespace Scoreboards
{
    public class ScoreboardWave : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform highscoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        [Header("Test")]
        [SerializeField] private string testEntryName = "New Name";
        [SerializeField] private int testEntryWave = 0;
        [SerializeField] private int testEntryScore = 0;

        private string SavePath => $"{Application.persistentDataPath}/wave_highscore.json";

        private void Start()
        {
            ScoreboardWaveSaveData savedScores = GetSavedScores();

            UpdateUI(savedScores);

            SaveScores(savedScores);
        }

        [ContextMenu("Add Test Entry")]
        public void AddTestEntry()
        {
            AddEntry(new ScoreboardWaveEntryData()
            {
                name = testEntryName,
                wave = testEntryWave,
                score = testEntryScore
            });
        }

        public void AddEntry(ScoreboardWaveEntryData scoreboardEntryData)
        {
            ScoreboardWaveSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            //Check if the score is high enough to be added.
            for (int i = 0; i < savedScores.highScores.Count; i++)
            {
                if (testEntryScore > savedScores.highScores[i].score)
                {
                    savedScores.highScores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            //Check if the score can be added to the end of the list.
            if (!scoreAdded && savedScores.highScores.Count < maxScoreboardEntries)
            {
                savedScores.highScores.Add(scoreboardEntryData);
            }

            //Remove any scores past the limit.
            if (savedScores.highScores.Count > maxScoreboardEntries)
            {
                savedScores.highScores.RemoveRange(maxScoreboardEntries, savedScores.highScores.Count - maxScoreboardEntries);
            }

            UpdateUI(savedScores);

            SaveScores(savedScores);
        }

        private void UpdateUI(ScoreboardWaveSaveData savedScores)
        {
            foreach (Transform child in highscoresHolderTransform)
            {
                Destroy(child.gameObject);
            }

            foreach (ScoreboardWaveEntryData highscore in savedScores.highScores)
            {
                Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<ScoreboardWaveEntryUI>().Initialise(highscore);
            }
        }

        private ScoreboardWaveSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardWaveSaveData();
            }

            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreboardWaveSaveData>(json);
            }
        }

        private void SaveScores(ScoreboardWaveSaveData scoreboardSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json);
            }
        }
    }
}