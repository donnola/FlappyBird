using UnityEngine;
using System;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


namespace Main
{
    public class Game : MonoBehaviour
    {
        public static event Action<int> GetPoint;
        public static event Action<bool> EndGame; 
        public static event Action<bool> StartGame; 
        private static int m_Point;
        private static int m_MaxScore;
        private static bool m_IsDie;
        public static bool IsDie => m_IsDie;
    
        public static int MaxScore => m_MaxScore;
        public static int Point => m_Point;

        private GameObject m_Pipe;
        private GameObject[] PipesArray;
        private int currentPipeID = 0;
        private int poolSize = 5;
        private float spawnX = 13f;
        private Vector2 PoolPosition = new Vector2(-15f, -25f);
        
        private SceneAsset m_UIScene;
    
        private void Awake()
        {
            PipesArray = new GameObject[poolSize];
            m_Pipe = GameAssets.GetInstance().Pipe;
            for (int i = 0; i < poolSize; i++)
            {
                PipesArray[i] = Instantiate(m_Pipe, PoolPosition, Quaternion.identity);
            }
            m_UIScene = GameAssets.GetInstance().UIScene;
            if (PlayerPrefs.HasKey("SavedMaxScore"))
            {
                m_MaxScore = PlayerPrefs.GetInt("SavedMaxScore");
            }
            m_Point = 0;
            GetPoint?.Invoke(m_Point);
            SceneManager.LoadScene(m_UIScene.name, LoadSceneMode.Additive);
        }
    
        private void Start()
        {
            m_IsDie = false;
            Time.timeScale = 0f;
            StartCoroutine(GeneratePipes());
        }
    
        IEnumerator GeneratePipes()
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0));
            StartGame?.Invoke(true);
            Time.timeScale = 1f;
            while (true)
            {
                float spawnY = Random.Range(-1.5f, 2.7f);
                PipesArray[currentPipeID].transform.position = new Vector2(spawnX, spawnY);
                currentPipeID++;
                if (currentPipeID >= poolSize)
                {
                    currentPipeID = 0;
                }

                yield return new WaitForSeconds(1f);
            }
        }
    
        public static void get_point()
        {
            Debug.Log("Point!");
            ++m_Point;
            GetPoint?.Invoke(m_Point);
        }
        public static void die()
        {
            m_IsDie = true;
            Time.timeScale = 0f;
            if (m_Point > m_MaxScore)
            {
                m_MaxScore = m_Point;
            }
            PlayerPrefs.SetInt("SavedMaxScore", Game.MaxScore);
            PlayerPrefs.Save();
            EndGame?.Invoke(true);
            Debug.Log("Die!");
        }
        
    }
}


