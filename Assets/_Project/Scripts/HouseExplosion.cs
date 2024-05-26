using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts
{
    public class HouseExplosion : MonoBehaviour
    {
        [SerializeField] private List<GameObject> HouseParts;
        private List<Vector3> OriginalScale = new List<Vector3>();
        private bool isExploding;
        
        [SerializeField] private GameObject DarkHouse;
        [SerializeField] private SpriteRenderer LightHousePartOne;
        [SerializeField] private SpriteRenderer LightHousePartTwo;
        [SerializeField] private SpriteRenderer LightHousePartThree;
        [SerializeField] private SpriteRenderer LightHousePartFour;

        private void Start()
        {
            foreach (GameObject part in this.HouseParts)
            {
                this.OriginalScale.Add(part.transform.localScale);
            }
            StartCoroutine(nameof(RandomPulsate));
            Invoke(nameof(Explode), 5);
            
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<PuzzlePossession>().OnPuzzleCollect += CollectPuzzle;
        }

        private void CollectPuzzle()
        {
            if (!this.LightHousePartOne.enabled)
            {
                this.LightHousePartOne.enabled = true;
                return;
            }
            
            if (!this.LightHousePartTwo.enabled)
            {
                this.LightHousePartTwo.enabled = true;
                return;
            }
            
            if (!this.LightHousePartThree.enabled)
            {
                this.LightHousePartThree.enabled = true;
                return;
            }
            
            if (!this.LightHousePartFour.enabled)
            {
                this.LightHousePartFour.enabled = true;
            }
        }

        private IEnumerator RandomPulsate()
        {
            while (!this.isExploding)
            {
                for (int i = 0; i < this.HouseParts.Count; i++)
                {
                    float scale = this.OriginalScale[i].x * (1 + Random.Range(-0.1f, 0.1f));
                    this.HouseParts[i].transform.localScale = new Vector3(scale, scale, scale);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }

        public void Explode()
        {
            this.isExploding = true;
            
            foreach (Rigidbody2D rb in this.HouseParts.Select(part => part.AddComponent<Rigidbody2D>()))
            {
                rb.AddForce(new Vector3(Random.Range(-1f, 1f) * 3, Random.Range(-1f, 1f)) * 500);
            }
            this.DarkHouse.SetActive(true);
            Invoke(nameof(DeleteAfterSeconds), 5);
        }
        
        private void DeleteAfterSeconds()
        {
            for (int i = this.HouseParts.Count - 1; i >= 0; i--)
            {
                Destroy(this.HouseParts[i]);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && this.LightHousePartFour.enabled)
            {
                other.GetComponent<PuzzlePossession>().Escape();
            }
        }
    }
}