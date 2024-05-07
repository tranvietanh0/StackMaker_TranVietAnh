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
            CheckPlayer();
        }
        
        private void CheckPlayer()
        {
            Ray ray = new Ray(transform.position - Vector3.forward, Vector3.up * 10f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag(GameTag.Player.ToString()))
                {
                    LevelManager.Instance().LoadLevel(1);
                }
            }
        }
    }
}