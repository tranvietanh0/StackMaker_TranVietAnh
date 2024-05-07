using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.StackMaker
{
    public class GameManager : GameObjectSingleton<GameManager>
    {

        private void Start()
        {
            if (PlayerPrefs.HasKey(GamePref.CurLevelId.ToString()))
            {
                int lastPlayedLevel = PlayerPrefs.GetInt(GamePref.CurLevelId.ToString());
                LevelManager.Instance().LoadLevel(lastPlayedLevel);
            }
            else
            {
                LevelManager.Instance().LoadLevel(0);
            }
        }

        public void SaveGame(int currentLevel)
        {
            // Lưu level hiện tại
            PlayerPrefs.SetInt(GamePref.CurLevelId.ToString(), currentLevel);
            PlayerPrefs.Save();
        }
    }
}
