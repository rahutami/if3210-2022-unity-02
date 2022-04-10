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
            Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<ScoreboardWaveEntryUI>().InitialiseTitle();
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
                ScoreboardWaveSaveData savedData = new ScoreboardWaveSaveData();
                while (savedData.highScores.Count < maxScoreboardEntries){
                    ScoreboardWaveEntryData entry = new ScoreboardWaveEntryData(){
                        name= "Shooter",
                        wave= 0,
                        score=0
                    };
                    savedData.highScores.Add(entry);
                }
                return savedData;
            }

            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                ScoreboardWaveSaveData savedData = JsonUtility.FromJson<ScoreboardWaveSaveData>(json);
                
                while (savedData.highScores.Count < maxScoreboardEntries){
                    ScoreboardWaveEntryData entry = new ScoreboardWaveEntryData(){
                        name= "Shooter",
                        wave= 0,
                        score=0
                    };
                    savedData.highScores.Add(entry);
                }
                return savedData;
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