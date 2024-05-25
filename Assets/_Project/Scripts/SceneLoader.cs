using UnityEngine;

namespace _Project.Scripts
{
    public enum EScene
    {
        TitleScreen,
        MainMenu,
        GameScene,
        GameOver
    }
    
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        
        public void LoadScene(EScene scene)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene((int)scene);
        }
    }
}