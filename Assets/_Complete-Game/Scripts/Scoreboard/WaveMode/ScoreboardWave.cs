using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace CompleteProject
{
    public class ScoreboardWave : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform highscoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        private string SavePath => $"{Application.persistentDataPath}/wave_highscore.json";

        private void Start()
        {
            ScoreboardWaveSaveData savedScores = GetSavedScores();

            UpdateUI(savedScores);

            SaveScores(savedScores);
        }

        [ContextMenu("Remove Entry")]
        public void RemoveEntry(){
            ScoreboardWaveSaveData savedScores = GetSavedScores();
            savedScores.highScores.RemoveRange(0, savedScores.highScores.Count);
            SaveScores(savedScores);
        }

        public void AddEntry(ScoreboardWaveEntryData scoreboardEntryData)
        {
            ScoreboardWaveSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            for (int i = 0; i < savedScores.highScores.Count; i++)
            {
                if (scoreboardEntryData.score > savedScores.highScores[i].score)
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