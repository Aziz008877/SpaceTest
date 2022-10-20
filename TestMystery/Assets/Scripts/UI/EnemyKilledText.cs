using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class EnemyKilledText : MonoBehaviour
    {
        private TextMeshProUGUI _enemyKilledText;
        private int _enemyKilled = 0;
        private void Awake()
        {
            _enemyKilledText = GetComponent<TextMeshProUGUI>();
            
            Bullet.Bullet.OnAsteroidKilled += IncreaseEnemyKilledValue;
            _enemyKilledText.text = $"Enemy Killed: {_enemyKilled++}";
        }

        private void IncreaseEnemyKilledValue()
        {
            _enemyKilledText.text = $"Enemy Killed: {_enemyKilled++}";
        }

        private void OnDestroy()
        {
            Bullet.Bullet.OnAsteroidKilled -= IncreaseEnemyKilledValue;
        }
    }
}
