using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class BottomsScripts: MonoBehaviour
    {
        public void RestartGame() 
        {
            SceneManager.LoadScene("Scenes/Game");
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}


