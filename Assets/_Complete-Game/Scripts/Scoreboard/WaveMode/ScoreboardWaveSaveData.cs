using System.Collections.Generic;
using System;

namespace CompleteProject{
    [Serializable]
    public class ScoreboardWaveSaveData
    {
        // Start is called before the first frame update
        public List<ScoreboardWaveEntryData> highScores = new List<ScoreboardWaveEntryData>();
    }

}
