using System.Collections.Generic;
using System;

namespace Scoreboards{
    [Serializable]
    public class ScoreboardWaveSaveData
    {
        // Start is called before the first frame update
        public List<ScoreboardWaveEntryData> highScores = new List<ScoreboardWaveEntryData>();
    }

}
