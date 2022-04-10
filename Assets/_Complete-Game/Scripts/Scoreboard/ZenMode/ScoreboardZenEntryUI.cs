using UnityEngine;
using TMPro;

namespace CompleteProject{
    public class ScoreboardZenEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI timeText;

        public void Initialise(ScoreboardZenEntryData entryData){
            nameText.text = entryData.name;
            int hour = entryData.time/3600;
            int remain = entryData.time%3600;
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
            timeText.text = time;
        }
    }

}
