using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Scripts.UI
{
    public class TitleScreenUI : MonoBehaviour
    {
        private VisualElement root;
        private VisualElement Info;
        
        private bool isInfoVisible = false;
        [SerializeField] private float waitTime = 1f;
        private bool isAnyKeyPressed = false;

        private void Start()
        {
            this.root = GetComponent<UIDocument>().rootVisualElement;
            this.Info = root.Q<VisualElement>("Info");

            //this.Info.visible = false;
            this.Info.style.opacity = 0;
            
        }

        private void Update()
        {
            if (this.isAnyKeyPressed) return;
            
            switch (this.isInfoVisible)
            {
                case true:
                {
                    if (Input.anyKey)
                    {
                        this.isAnyKeyPressed = true;
                        SceneLoader.Instance.LoadScene(EScene.MainMenu);
                    }
                    break;
                }
                case false when Input.anyKey:
                    this.Info.style.opacity = 1;
                    this.isInfoVisible = true;
                    break;
            }
            
            this.waitTime -= Time.deltaTime;
            if (this.waitTime >= 0) return;

            if (this.Info.style.opacity.value > 0.99f)
            {
                this.Info.style.opacity = 1;
                this.isInfoVisible = true;
            }
            
            this.Info.style.opacity = Mathf.Lerp(this.Info.style.opacity.value, 1, Time.deltaTime * .5f);
        }
    }
}