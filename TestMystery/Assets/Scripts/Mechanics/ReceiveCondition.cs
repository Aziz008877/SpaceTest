using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Mechanics
{
    public class ReceiveCondition : MonoBehaviour
    {
        private int _asteroidsCount;
        private GameObject _asteroidType = null;
        private float _xSpawnPosition;
        private float _ySpawnPosition = 15;
        [SerializeField] private GameObject _player;
        [SerializeField] private UnityEvent _onPlayerWin;

        private void Awake()
        {
            _asteroidType = MenuButtons.SelectedAsteroid;
            _asteroidsCount = MenuButtons.SelectedCount;
            
            StartCoroutine(SpawnAsteroids());
        }
        
        private IEnumerator SpawnAsteroids()
        {
            while (_asteroidsCount > 0)
            {
                yield return new WaitForSeconds(1);
                _asteroidsCount--;
                _xSpawnPosition = Random.Range(-6, 6);
                Instantiate(_asteroidType, new Vector2(_xSpawnPosition, _ySpawnPosition), quaternion.identity);
            }

            yield return new WaitForSeconds(2);

            if (_player.activeInHierarchy)
            {
                if ( MenuButtons.LevelPassed < 3)
                {
                    var openNewLevel = MenuButtons.LevelPassed++;
                    PlayerPrefs.SetInt("LevelCount", MenuButtons.LevelPassed);
                }
                _onPlayerWin?.Invoke();
                
            }
            
        }
    }
}
