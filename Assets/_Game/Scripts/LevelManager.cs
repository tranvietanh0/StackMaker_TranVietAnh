using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.StackMaker
{
    public class LevelManager : GameObjectSingleton<LevelManager>
    {
        public List<GameObject> levelPrefabs;
        public int levelId;

        [SerializeField]private GameObject currentLevelPrefab; 
        [SerializeField]private GameObject currentLevelInstance;

        [SerializeField] private List<Map> maps = new List<Map>();

        public void LoadLevel(int levelIndex)
        {
            if (levelIndex < 0 || levelIndex >= levelPrefabs.Count)
            {
                Debug.LogWarning("Level index out of range!");
                return;
            }

            if (currentLevelInstance != null)
            {
                Debug.Log("huy");
                Destroy(currentLevelInstance);
            }

            currentLevelPrefab = levelPrefabs[levelIndex];
            // PlayerController.Instance.OnInit();
            currentLevelInstance = Instantiate(currentLevelPrefab);
            currentLevelInstance.SetActive(true);
            for (int i = 0; i < PlayerController.Instance.Bricks.Count; i++)
            {
                Destroy(PlayerController.Instance.Bricks[i]);
            }
            Map map = Instantiate(maps[levelIndex]);
            PlayerController.Instance.SetStartPosition(map.StartPosition);
            // currentLevelInstance.transform.position = Vector3.zero;
            // currentLevelInstance.transform.localScale = Vector3.one;
            // currentLevelInstance.transform.rotation = Quaternion.identity;
        }
        
    }

}
