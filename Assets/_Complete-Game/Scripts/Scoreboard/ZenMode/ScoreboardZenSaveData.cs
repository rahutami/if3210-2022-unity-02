using System.Collections.Generic;
using System;

namespace Scoreboards{
    [Serializable]
    public class ScoreboardZenSaveData
    {
        // Start is called before the first frame update
        public List<ScoreboardZenEntryData> highScores = new List<ScoreboardZenEntryData>();
    }

}
