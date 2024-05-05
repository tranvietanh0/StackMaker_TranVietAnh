using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.StackMaker
{
    public class LevelManager : GameObjectSingleton<LevelManager>
    {
        
        [SerializeField]private List<GameObject> levelList = new List<GameObject>();

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
                    // di vao level dau tien
                }
                else
                {
                    //check du lieu luu xuong may ng choi chua 
                }
            }
        }
        
    }
}
