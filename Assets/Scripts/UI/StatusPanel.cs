using UnityEngine;
using UnityEngine.UI;
using Main;

namespace UI
{
    public class StatusPanel : MonoBehaviour
    {
        [SerializeField] 
        private GameObject m_StartStatusPanel;
        [SerializeField] 
        private GameObject m_GameStatusPanel;
        [SerializeField] 
        private Text m_MaxScoreStart;
        [SerializeField] 
        private Text m_MaxScoreGame;

        private void Start()
        {
            m_StartStatusPanel.SetActive(true);
            m_GameStatusPanel.SetActive(false);
            if (Game.MaxScore > 0)
            {
                m_MaxScoreStart.text = $"Рекорд {Game.ScoreName}: {Game.MaxScore}";
                m_MaxScoreGame.text = $"Рекорд {Game.ScoreName}: {Game.MaxScore}";
            }
            else
            {
                m_MaxScoreStart.text = "";
                m_MaxScoreGame.text = "";
            }
        }

        private void OnEnable()
        {
            Game.StartGame += ActivateEndPanel;
        }
    
        private void OnDisable()
        {
            Game.StartGame -= ActivateEndPanel;
        }

        private void ActivateEndPanel(bool start)
        {
            m_StartStatusPanel.SetActive(false);
            m_GameStatusPanel.SetActive(true);
        }
    }
}

