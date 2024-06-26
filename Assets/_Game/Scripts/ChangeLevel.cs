using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.StackMaker
{
    public class ChangeLevel : MonoBehaviour
    {
        private void Update()
        {
            if (CheckPlayer())
            {
                UIManager.Instance().winGUI.SetActive(true);
                Destroy(LevelManager.Instance().currentLevelInstance);
            }
            GameManager.Instance().SaveGame(Pref.curPlayerLevel);
        }
        
        private bool CheckPlayer()
        {
            Ray ray = new Ray(transform.position - Vector3.forward, Vector3.up * 10f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag(GameTag.Player.ToString()))
                {
                    PlayerController.Instance.OnInit();
                    hit.transform.gameObject.tag = "Untagged";
                    Debug.Log(Pref.curPlayerLevel);
                    // LevelManager.Instance().LoadLevel(Pref.curPlayerLevel);
                    // Pref.curPlayerLevel++;
                    if (Pref.curPlayerLevel > LevelManager.Instance().levelPrefabs.Count)
                    {
                        Pref.curPlayerLevel = 0;
                    }

                    return true;
                }
            }

            return false;
        }

    }
}