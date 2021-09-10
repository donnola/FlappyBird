using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Main
{
    public class GameAssets : MonoBehaviour
    {
        private static GameAssets instance;

        [SerializeField] private GameObject m_Pipe; 
        public GameObject Pipe => m_Pipe;
        
        [SerializeField] private SceneAsset m_UIScene;
        public SceneAsset UIScene => m_UIScene;
    

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

