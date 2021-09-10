using UnityEngine;
using System;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;

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
        private SceneAsset m_UIScene;
    
        private void Awake()
        {
            m_Pipe = GameAssets.GetInstance().Pipe;
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
            Vector2 position;
            while(true)
            {
                position = transform.position;
                position.x += 14f;
                Instantiate(m_Pipe, position, Quaternion.identity);
                yield return new WaitForSeconds(1.0F);
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


