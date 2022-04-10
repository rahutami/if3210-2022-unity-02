using UnityEngine;
using TMPro;

namespace CompleteProject{
    public class ScoreboardWaveEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI waveText;
        [SerializeField] private TextMeshProUGUI scoreText;

        public void Initialise(ScoreboardWaveEntryData entryData){
            nameText.text = entryData.name;
            waveText.text = entryData.wave.ToString();
            scoreText.text = entryData.score.ToString();
        }
    }

}
