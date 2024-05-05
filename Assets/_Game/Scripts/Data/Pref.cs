using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.StackMaker
{
    public static class Pref
    {
        public static int CurLevelId
        {
            set => PlayerPrefs.SetInt(GamePref.CurLevelId.ToString(), value);
            get => PlayerPrefs.GetInt(GamePref.CurLevelId.ToString(), 0);
        }

        public static void SetLevelUnlocked(int levelId, bool unlocked)
        {
            //level unlocked 1
            SetBool(GamePref.LevelUnlocked.ToString() + levelId, unlocked);
        }

        public static bool IsLevelUnlocked(int levelId)
        {
            return GetBool(GamePref.LevelUnlocked.ToString() + levelId);
        }
        public static void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        public static bool GetBool(string key, bool defaultValue = false)
        {
            return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetInt(key) == 1 ? true : false : defaultValue;
        }
    }
}