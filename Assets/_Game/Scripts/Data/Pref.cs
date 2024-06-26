using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.StackMaker
{
    public static class Pref
    {
        public static int curPlayerLevel
        {
            set => PlayerPrefs.SetInt(GamePref.CurLevelId.ToString(), value);
            get => PlayerPrefs.GetInt(GamePref.CurLevelId.ToString(), 0);
        }

        public static int score
        {
            set => PlayerPrefs.SetInt(GamePref.Score.ToString(), value);
            get => PlayerPrefs.GetInt(GamePref.Score.ToString(), 0);
        }
        
    }
}
