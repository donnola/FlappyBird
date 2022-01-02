using UnityEngine;
using System;
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
        
        private static int m_Score;
        public static int Score => m_Score;

        private static int m_MaxScore = 0;
        public static int MaxScore => m_MaxScore;

        private static string m_ScoreName = "";
        public static string ScoreName => m_ScoreName;

        private static bool m_IsDie;
        public static bool IsDie => m_IsDie;
    
        private int PoolSize = 5;
        private GameObject[] PipesArray;
        private Vector2 PoolPosition = new Vector2(-15f, -25f);
        private int CurrentPipeID;
        private float spawnX = 13f;
        
        private void Awake()
        {
            Time.timeScale = 0f;
            GameObject m_Pipe = GameAssets.GetInstance().Pipe;
            PipesArray = new GameObject[PoolSize];
            for (int i = 0; i < PoolSize; i++)
            {
                PipesArray[i] = Instantiate(m_Pipe, PoolPosition, Quaternion.identity);
            }
            if (PlayerPrefs.HasKey("SavedMaxScore"))
            {
                m_MaxScore = PlayerPrefs.GetInt("SavedMaxScore");
            }
            if (PlayerPrefs.HasKey("SetNameScore"))
            {
                m_ScoreName = PlayerPrefs.GetString("SetNameScore");
            }
            SceneManager.LoadScene("Scenes/UI", LoadSceneMode.Additive);
        }
    
        private void Start()
        {
            m_Score = 0;
            m_IsDie = false;
            GetPoint?.Invoke(m_Score);
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
                PipesArray[CurrentPipeID].transform.position = new Vector2(spawnX, spawnY);
                CurrentPipeID++;
                if (CurrentPipeID >= PoolSize)
                {
                    CurrentPipeID = 0;
                }

                yield return new WaitForSeconds(1f);
            }
        }
    
        public static void AddPoint()
        {
            Debug.Log("Point!");
            ++m_Score;
            GetPoint?.Invoke(m_Score);
        }
        public static void Die()
        {
            m_IsDie = true;
            Time.timeScale = 0f;
            EndGame?.Invoke(true);
            Debug.Log("Die!");
        }

        public static void SaveScore(string name)
        {
            m_MaxScore = m_Score;
            m_ScoreName = name;
            PlayerPrefs.SetInt("SavedMaxScore", m_MaxScore);
            PlayerPrefs.SetString("SetNameScore", m_ScoreName);
            PlayerPrefs.Save();
        }

        public static void DeleteScore()
        {
            m_MaxScore = 0;
            m_ScoreName = "";
            PlayerPrefs.SetInt("SavedMaxScore", m_MaxScore);
            PlayerPrefs.SetString("SetNameScore", m_ScoreName);
            PlayerPrefs.Save();
        }
        
    }
}


