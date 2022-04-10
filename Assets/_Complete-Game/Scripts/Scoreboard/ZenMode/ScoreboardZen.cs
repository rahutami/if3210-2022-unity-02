using System.IO;
using UnityEngine;

namespace Scoreboards
{
    public class ScoreboardZen : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform highscoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        [Header("Test")]
        [SerializeField] private string testEntryName = "New Name";
        [SerializeField] private int testEntryTime = 0;

        private string SavePath => $"{Application.persistentDataPath}/zen_highscore.json";

        private void Start()
        {
            ScoreboardZenSaveData savedScores = GetSavedScores();

            UpdateUI(savedScores);

            SaveScores(savedScores);
        }

        [ContextMenu("Add Test Entry")]
        public void AddTestEntry()
        {
            AddEntry(new ScoreboardZenEntryData()
            {
                name = testEntryName,
                time = testEntryTime
            });
        }

        public void AddEntry(ScoreboardZenEntryData scoreboardEntryData)
        {
            ScoreboardZenSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            //Check if the score is high enough to be added.
            for (int i = 0; i < savedScores.highScores.Count; i++)
            {
                if (testEntryTime > savedScores.highScores[i].time)
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
                Debug.Log("removing");
                savedScores.highScores.RemoveRange(maxScoreboardEntries, savedScores.highScores.Count - maxScoreboardEntries);
            }

            UpdateUI(savedScores);

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