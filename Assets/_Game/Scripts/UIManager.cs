using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace VANH.StackMaker
{
    public class UIManager : GameObjectSingleton<UIManager>
    {
        public GameObject homeGUI;
        public GameObject gameGUI;
        public GameObject winGUI;
        public GameObject levelSelectDialog;
        public TextMeshProUGUI mainScoreTxt;

        private void Start()
        {
            
        }

        public void ShowGameGUI(bool isShow)
        {
            if (gameGUI)
            {
                gameGUI.SetActive(isShow);
            }

            if (homeGUI)
            {
                homeGUI.SetActive(!isShow);
            }
        }

        public void ShowLevelSelect(bool isShow)
        {
            if (levelSelectDialog)
            {
                levelSelectDialog.SetActive(isShow);
            }
        }

        

        // public void BackToMenu(bool isShow)
        // {
        //     if (backDialog)
        //     {
        //         backDialog.SetActive(isShow);
        //     }
        // }
        public void TurnOffSelectDialog()
        {
            if (levelSelectDialog)
            {
                levelSelectDialog.SetActive(false);
            }
        }

        public void ShowWinGUI(bool isShow)
        {
            if (winGUI)
            {
                winGUI.SetActive(isShow);
            }
        }

        public void UpdateScore()
        {
            if (mainScoreTxt)
            {
                mainScoreTxt.text = PlayerController.Instance.score.ToString();
            }
        }
    }
}
