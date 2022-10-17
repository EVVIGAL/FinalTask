using UnityEngine;
using TMPro;

public class ScoreSaver : MonoBehaviour
{
    [SerializeField] private TMP_Text _highScore;
    [SerializeField] private EnemyCounter _enemyCounter;

    private string _highScoreKey = "Highscore";
    private string _bestScoreText = "Best score: ";

    private void Start()
    {
        _highScore.text = _bestScoreText + PlayerPrefs.GetInt(_highScoreKey, 0).ToString();
    }

    private void Update()
    {
        if (_enemyCounter.Score > PlayerPrefs.GetInt(_highScoreKey, 0))
        {
            PlayerPrefs.SetInt(_highScoreKey, _enemyCounter.Score);
            _highScore.text = _bestScoreText + _enemyCounter.Score.ToString();
        }
    }
}
