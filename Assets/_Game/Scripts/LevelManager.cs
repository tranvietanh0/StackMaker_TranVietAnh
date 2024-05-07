using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.StackMaker
{
    // public class LevelManager : GameObjectSingleton<LevelManager>
    // {
    //     
    //     [SerializeField] private List<GameObject> levelList = new List<GameObject>();
    //
    //     [SerializeField] private List<Map> maps = new();
    //
    //     private static int currentLevel = 1;
    //     public List<GameObject> LevelList
    //     {
    //         get => levelList;
    //         set => levelList = value;
    //     }
    //
    //     public int CurrentLevel
    //     {
    //         get => currentLevel;
    //         set => currentLevel = value;
    //     }
    //     
    //     public void PositionPlayer()
    //     {
    //         // lay ra tu PlayPrefs
    //         Map map = Instantiate(maps[currentLevel - 1]);
    //         PlayerController playerController = new PlayerController();
    //         playerController.SetStartPosition(map.StartPosition);
    //     }
    //     
    // }

    public class LevelManager : GameObjectSingleton<LevelManager>
    {
        [SerializeField]private List<GameObject> levelPrefabs; 

        [SerializeField]private GameObject currentLevelPrefab; 
        [SerializeField]private GameObject currentLevelInstance; 

        public void LoadLevel(int levelIndex)
        {
            if (levelIndex < 0 || levelIndex >= levelPrefabs.Count)
            {
                Debug.LogWarning("Level index out of range!");
                return;
            }

           
            if (currentLevelInstance != null)
            {
                Destroy(currentLevelInstance);
            }

            currentLevelPrefab = levelPrefabs[levelIndex];

            currentLevelInstance = Instantiate(currentLevelPrefab);
            currentLevelInstance.SetActive(true);
            // currentLevelInstance.transform.position = Vector3.zero;
            // currentLevelInstance.transform.localScale = Vector3.one;
            // currentLevelInstance.transform.rotation = Quaternion.identity;
        }
    }

}
