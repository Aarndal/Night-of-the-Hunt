using UnityEngine;

namespace _Project.Scripts.UI
{
    public class QuitGameButton : MonoBehaviour
    {
        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

        }
    }
}