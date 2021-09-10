using UnityEngine;

namespace Main
{
    public class GameAssets : MonoBehaviour
    {
        private static GameAssets instance;

        [SerializeField] private GameObject m_Pipe; 
        public GameObject Pipe => m_Pipe;

        public static GameAssets GetInstance()
        {
            return instance;
        }

        private void Awake()
        {
            instance = this;
        }

    }
}

