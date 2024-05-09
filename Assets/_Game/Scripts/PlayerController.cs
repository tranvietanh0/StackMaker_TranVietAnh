using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace VANH.StackMaker
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance { get; private set; }
        public List<GameObject> Bricks = new List<GameObject>();
        
        [SerializeField] private float moveSpeed = 5f;
        
        [SerializeField] private Direction m_direction;

        [SerializeField] private GameObject brickPrefab;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject brickOnBridge;
        
        private Vector2 m_startMousePos, m_endMousePos;
        private Vector3 m_targetPos;
        private Stack<Transform> m_brickStack = new Stack<Transform>();
        private bool isFinish = false;
        public int score = 0;

        // public int Score
        // {
        //     get => score;
        // }


        private void Awake() 
        {     
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            } 
        }

        private void Start()
        {
            
        }
        private void Update()
        {
            CheckInput();
            Move();
            if (CheckBrick())
            {
                player.gameObject.transform.GetChild(0).gameObject.tag = GameTag.Player.ToString();
                AddBrick();
                score++;
            }
            if(CheckUnBrick())
            {
                RemoveBrick();
            }
        }

        public void OnInit()
        {
            // player.gameObject.tag = GameTag.Player.ToString();
            // player.gameObject.transform.GetChild(0).gameObject.tag = GameTag.Player.ToString();
            m_direction = Direction.None;
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
            Ray ray = new Ray(transform.position + vectorDirection * 0.6f, Vector3.down);
            RaycastHit hit;
            int countBrick = 0;
            int countUnBrick = 0;
            int countPath = 0;
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
                else if(hit.collider.CompareTag(GameTag.Finish.ToString()))
                {
                    countPath++;
                }
                else if (hit.collider.CompareTag(GameTag.Destination.ToString()))
                {
                    RemoveBrick();
                    Debug.Log("win");
                }
            }
            //tim target sau moi lan di chuyen
            m_targetPos = transform.position + (countBrick + countUnBrick + countPath) * vectorDirection;
            transform.position = Vector3.MoveTowards(transform.position, m_targetPos, moveSpeed * Time.deltaTime);
        }

        private bool CheckBrick()
        {
            Vector3 vectorDirection = GetDirection(m_direction);
            Ray ray = new Ray(transform.position - vectorDirection, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag(GameTag.Brick.ToString()))
                {
                    hit.collider.gameObject.SetActive(false);
                    return true;
                }
            }
            return false;
        }
        private bool CheckUnBrick()
        {
            Vector3 vectorDirection = GetDirection(m_direction);
            Ray ray = new Ray(transform.position - vectorDirection, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag(GameTag.UnBrick.ToString()))
                {
                    // doit tag gameobj thanh finish de k check collider lien tuc
                    // hit.collider.enabled = !hit.collider.enabled;
                    Vector3 brickSpawnBridge = hit.transform.position + Vector3.up * 0.01f;
                    Bricks.Add(Instantiate(brickOnBridge, brickSpawnBridge, hit.transform.rotation));
                    hit.collider.gameObject.tag = "Finish";
                    return true;
                }
            }
            return false;
        }
        
        private void AddBrick()
        {
            //goi ra obj con cua prefab brick 
            Transform brickChildPath = brickPrefab.gameObject.transform.GetChild(0);
            //lay ra anim
            GameObject playerAnim = player.transform.GetChild(0).gameObject;
            playerAnim.transform.position += Vector3.up * 0.3f;
            Transform brickObject = Instantiate(brickChildPath, playerAnim.transform.position + Vector3.down * 0.7f,
                brickChildPath.transform.rotation);
            m_brickStack.Push(brickObject);
            brickObject.SetParent(player.transform);
            brickChildPath.gameObject.SetActive(true);
        }

        private void RemoveBrick()
        {
            Transform unBrickChild = brickPrefab.transform.GetChild(0);
            GameObject playerAnim = player.transform.GetChild(0).gameObject;
            if (m_brickStack.Count > 0)
            {
                GameObject destroyBrick = m_brickStack.Pop().gameObject;
                Destroy(destroyBrick);
                playerAnim.transform.position += Vector3.down * 0.3f;
                unBrickChild.gameObject.SetActive(true);    
            }
        }

        //lay huong di chuyen
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

        public void SetStartPosition(Transform mapStartPosition)
        {
            transform.position = mapStartPosition.position + Vector3.up * 3f;
        }
    }
}