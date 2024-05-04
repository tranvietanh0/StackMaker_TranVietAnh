using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.StackMaker
{
    public class CameraFollow : MonoBehaviour
    {

        public Transform target; 
        public Vector3 offset; 

        void LateUpdate()
        {
            Vector3 newPosition = target.position + offset;
            transform.position = newPosition;
        }
    }
}
