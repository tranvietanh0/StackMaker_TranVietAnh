using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.StackMaker
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private float moveSpeed = 5f;
        
        [SerializeField] private Direction m_direction;
        private Vector2 m_startMousePos, m_endMousePos;

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
            Ray ray = new Ray(transform.position, vectorDirection.normalized);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Wall"))
                {
                    Debug.Log("cham tuong");
                }
                Debug.DrawRay(transform.position, transform.position + vectorDirection, Color.red);
                Vector3 nextPos = Vector3.MoveTowards(transform.position, transform.position + vectorDirection,
                    moveSpeed * Time.deltaTime);
                transform.position = nextPos;
            }
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