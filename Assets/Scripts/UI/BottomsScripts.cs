using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class BottomsScripts: MonoBehaviour
    {
        [SerializeField] 
        public SceneAsset m_Scene;
        public void RestartGame() 
        {
            SceneManager.LoadScene(m_Scene.name);
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}


