using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace VANH.StackMaker
{
    public class UIManager : GameObjectSingleton<UIManager>
    {
        public GameObject homeGUI;
        public GameObject gameGUI;
        public Text mainScoreTxt;

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

        public void UpdateScore()
        {
            if (mainScoreTxt)
            {
                mainScoreTxt = PlayerController.Instance.score.ToString();
            }
        }
    }
}
