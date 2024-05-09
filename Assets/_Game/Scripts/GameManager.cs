using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.StackMaker
{
    public class GameManager : GameObjectSingleton<GameManager>
    {
        [SerializeField] private UIManager guiMng;

        private void Awake()
        {
            guiMng.ShowGameGUI(false);
        }

        

        public void PlayGame()
        {
            PlayerController.Instance.OnInit();
            guiMng.ShowGameGUI(true);
            guiMng.UpdateScore();
            if (PlayerPrefs.HasKey(GamePref.CurLevelId.ToString()))
            {
                int lastPlayedLevel = PlayerPrefs.GetInt(GamePref.CurLevelId.ToString());
                LevelManager.Instance().LoadLevel(lastPlayedLevel - 1);
            }
            else
            {
                LevelManager.Instance().LoadLevel(0);
            }
        }

        public void SelectLevel()
        {
            guiMng.ShowLevelSelect(true);
        }

        public void Back()
        {
            guiMng.ShowLevelSelect(false);
        }
        public void SaveGame(int currentLevel)
        {
            // Lưu level hiện tại
            PlayerPrefs.SetInt(GamePref.CurLevelId.ToString(), currentLevel);
            PlayerPrefs.Save();
        }
    }
}
