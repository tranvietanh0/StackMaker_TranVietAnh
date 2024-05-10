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
            guiMng.ShowGameGUI(true);
            guiMng.UpdateScore();
            if (PlayerPrefs.HasKey(GamePref.CurLevelId.ToString()))
            {
                int lastPlayedLevel = PlayerPrefs.GetInt(GamePref.CurLevelId.ToString());
                LevelManager.Instance().LoadLevel(lastPlayedLevel);
            }
            else
            {
                LevelManager.Instance().LoadLevel(0);
            }
            PlayerController.Instance.OnInit();
        }

        public void SelectLevel()
        {
            guiMng.ShowLevelSelect(true);
        }

        public void Back()
        {
            guiMng.ShowLevelSelect(false);
        }

        public void Retry()
        {
            Debug.Log("da bam retry");
            Debug.Log(Pref.curPlayerLevel);
            LevelManager.Instance().LoadLevel(Pref.curPlayerLevel);
        }

        public void NextLevel()
        {
            Debug.Log("da bam next");
            Debug.Log(Pref.curPlayerLevel);
            Pref.curPlayerLevel++;
            LevelManager.Instance().LoadLevel(Pref.curPlayerLevel);
        }
        public void SaveGame(int currentLevel)
        {
            // Lưu level hiện tại
            PlayerPrefs.SetInt(GamePref.CurLevelId.ToString(), currentLevel);
            PlayerPrefs.Save();
        }
    }
}
