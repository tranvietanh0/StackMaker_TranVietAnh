using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VANH.StackMaker
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private float moveSpeed = 5f;
        
        [SerializeField] private Direction m_direction;
        private Vector2 m_startMousePos, m_endMousePos;
        private Vector3 targetPos;
        private void Start()
        {
            
        }

        private void Update()
        {
            CheckInput();
            Move();
        }
        

        private void CheckInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_startMousePos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                m_endMousePos = Input.mousePosition;
                Vector2 dir = m_endMousePos - m_startMousePos;
                if (Math.Abs(dir.x) > Math.Abs(dir.y))
                {
                    if (dir.x > 0)
                    {
                        m_direction = Direction.Right;
                    }
                    else
                    {
                        m_direction = Direction.Left;
                    }
                }
                else
                {
                    if (dir.y > 0)
                    {
                        m_direction = Direction.Forward;
                    }
                    else
                    {
                        m_direction = Direction.Backward;
                    }
                }
            }
        }
        private void Move()
        {
            Vector3 vectorDirection = GetDirection(m_direction);
            Ray ray = new Ray(transform.position + vectorDirection * 0.5f, Vector3.down);
            RaycastHit hit;
            int countBrick = 0;
            int countUnBrick = 0;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(transform.position + vectorDirection,Vector3.up * 5f, Color.red);
                if (hit.collider.CompareTag(GameTag.Brick.ToString()))
                {
                    countBrick++;
                }
                else if(hit.collider.CompareTag(GameTag.UnBrick.ToString()))
                {
                    countUnBrick++;
                }
            }
            targetPos = transform.position + (countBrick + countUnBrick) * vectorDirection ;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }

        private Vector3 GetDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:
                    return Vector3.left;
                case Direction.Right:
                    return Vector3.right;
                case Direction.Backward:
                    return Vector3.back;
                case Direction.Forward:
                    return Vector3.forward;
                default: return Vector3.zero;
            }
        }
    }
}