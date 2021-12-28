using System;
using Main;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class BottomsScripts: MonoBehaviour
    {
        private static string m_ScoreName;
        public void RestartGame() 
        {
            SceneManager.LoadScene("Scenes/Game");
        }
        public void Exit()
        {
            Application.Quit();
        }

        public void SaveScore()
        {
            Game.save_score(m_ScoreName);
            SceneManager.LoadScene("Scenes/Game");
        }

        public void DeleteScore()
        {
            Game.delete_score();
            SceneManager.LoadScene("Scenes/Game");
        }

        public static void InputName(InputField userInput)
        {
            m_ScoreName = userInput.text;
        }
    }
}


