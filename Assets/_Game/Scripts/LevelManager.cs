using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.StackMaker
{
    public class LevelManager : GameObjectSingleton<LevelManager>
    {
        
        [SerializeField] private List<GameObject> levelList = new List<GameObject>();
        [SerializeField] private List<Map> maps = new();
        
        private void OnInit()
        {
            if (levelList == null || levelList.Count <= 0)
            {
                return;
            }

            for (int i = 0; i < levelList.Count; i++)
            {
                GameObject level = levelList[i];
                if (level == null)
                {
                    continue;
                }

                if (i == 0)
                {
                    Pref.SetLevelUnlocked(i , true);
                }
                else
                {
                    //check du lieu luu xuong may ng choi chua 
                }
            }
            
            // lay ra tu PlayPrefs
            // int currentLevel = 1;
            // Map map = Instantiate(maps[currentLevel - 1]);
            // PlayerController playerController;
            // playerController.SetStartPosition(map.StartPosition);
        }
        
    }
}
