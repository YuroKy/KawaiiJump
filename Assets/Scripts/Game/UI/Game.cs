using Assets.Scripts.Game.Player;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Game.UI
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private Stats _playerStats;

        public void UpdateScore(int score)
        {
            _scoreText.SetText($"Score: {score}");
        }

        private void Start()
        {
            _playerStats = FindObjectOfType<Stats>();
            _playerStats.OnScoreUpdated += UpdateScore;
        }

        private void OnDestroy()
        {
            _playerStats.OnScoreUpdated -= UpdateScore;
        }
    }
}
