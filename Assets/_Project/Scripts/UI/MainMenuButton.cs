using System;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class MainMenuButton : MonoBehaviour
    {
        public void GoToMainMenu()
        {
            Time.timeScale = 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}