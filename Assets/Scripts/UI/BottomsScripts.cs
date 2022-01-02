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
            Game.SaveScore(m_ScoreName);
        }

        public void DeleteScore()
        {
            Game.DeleteScore();
        }

        public static void InputName(InputField userInput)
        {
            m_ScoreName = userInput.text;
        }
    }
}


