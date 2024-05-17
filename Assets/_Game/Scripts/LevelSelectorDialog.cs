using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VANH.StackMaker
{
    public class LevelSelectorDialog : MonoBehaviour
    {
        public List<GameObject> levelButtonPrefab = new List<GameObject>();

        // Parent transform để đặt button level vào
        public List<Transform> buttonParent = new List<Transform>();

        // Số lượng level trong game
        public int numberOfLevels = 5;

        private void Start()
        {
            // Tạo button cho từng level
            for (int i = 1; i <= numberOfLevels; i++)
            {
                Debug.Log(i);
                // Tạo một button mới từ prefab
                GameObject button = Instantiate(levelButtonPrefab[i - 1], buttonParent[i - 1]);
                // Lấy component Button từ button mới tạo
                Button buttonComponent = button.GetComponent<Button>();
                int levelIndex = i;
                buttonComponent.onClick.AddListener(() => LevelManager.Instance().LoadLevel(levelIndex - 1));
                // button.GetComponentInChildren<Text>().text = "Level " + i;
                // PlayerController.Instance.OnInit();
            }
        }
    }
}
