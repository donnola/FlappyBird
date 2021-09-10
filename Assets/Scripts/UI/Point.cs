using UnityEngine.UI;
using Main;
using UnityEngine;

namespace UI
{
    public class Point : MonoBehaviour
    {
        [SerializeField] 
        private Text m_Text;
    
        private void OnEnable()
        {
            Game.GetPoint += ChangeMark;
            ChangeMark(Game.Point);
        }

        private void OnDisable()
        {
            Game.GetPoint -= ChangeMark;
        }

        void ChangeMark(int point)
        {
            m_Text.text = $"{point}";
        }
    }
}

