using Main;
using UnityEngine;

namespace UI
{
    public class EndPanel : MonoBehaviour
    {
        [SerializeField] 
        private GameObject m_EndPanel;
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
        }
    }
}

