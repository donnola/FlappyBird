using System;
using Main;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EndPanel : MonoBehaviour
    {
        [SerializeField] 
        private GameObject m_EndPanel;

        [SerializeField] 
        private GameObject m_SaveScoreBottom;

        [SerializeField] 
        private InputField m_InputNameField;

        private void Start()
        {
            m_InputNameField.onEndEdit.AddListener(delegate { BottomsScripts.InputName(m_InputNameField); });
        }

        private void OnEnable()
        {
            Game.EndGame += ActivateEndPanel;
        }
    
        private void OnDisable()
        {
            Game.EndGame -= ActivateEndPanel;
        }

        private void ActivateEndPanel(bool is_died)
        {
            m_EndPanel.SetActive(true);
            if (Game.Score <= Game.MaxScore)
            {
                m_SaveScoreBottom.SetActive(false);
                m_InputNameField.gameObject.SetActive(false);
            }
        }
    }
}

