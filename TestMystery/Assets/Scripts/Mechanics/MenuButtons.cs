using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Mechanics
{
    public class MenuButtons : MonoBehaviour
    {
        [SerializeField] private Ease _easeType;
        [SerializeField] private float _duration;
        [SerializeField] private List<Transform> _levelIcons;
        [SerializeField] private List<GameObject> _asteroidTypes;
        private List<int> _asteroidCount = new List<int>{10, 15, 20};
        public static Action<GameObject, int> OnConditionsRandomed;
        public static GameObject SelectedAsteroid = null;
        public static int SelectedCount;
        public static int LevelPassed;
        private void Awake()
        {
            OpenPassedLevels();
            ScaleUI();
            AddListener();
        }

        private void OpenPassedLevels()
        {
            if (PlayerPrefs.GetInt("LevelCount") == 0)
            {
                LevelPassed = 1;
            }
            else
            {
                LevelPassed = PlayerPrefs.GetInt("LevelCount");
            }
            
            for (int i = 0; i < LevelPassed; i++)
            {
                _levelIcons[i].GetComponent<Button>().interactable = true;
            }
        }
        private void ScaleUI()
        {
            foreach (var icon in _levelIcons)
            {
                icon.DOScale(new Vector2(1.1f, 1.1f), _duration)
                    .SetEase(_easeType)
                    .SetLoops(-1, LoopType.Yoyo);
            }
        }

        private void AddListener()
        {
            for (int i = 0; i < _levelIcons.Count; i++)
            {
                _levelIcons[i].gameObject.GetComponent<Button>().onClick.AddListener(RandomConditions);
                _levelIcons[i].gameObject.GetComponent<Button>().onClick.AddListener(LoadGame);
            }
        }

        private void RandomConditions()
        {
            int randomType = Random.Range(0, _asteroidTypes.Count);
            var randomedAsteroid = _asteroidTypes[randomType];
            _asteroidTypes.Remove(_asteroidTypes[randomType].gameObject);
            
            int randomCount = Random.Range(0, _asteroidCount.Count);
            var randomedCount = _asteroidCount[randomCount];
            _asteroidCount.Remove(_asteroidCount[randomCount]);
            
            SelectedAsteroid = randomedAsteroid;
            SelectedCount = randomedCount;
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }

        private void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
