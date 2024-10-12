using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _targets;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _gameOverText;
    [SerializeField]
    private Button _restartButton;
    [SerializeField] 
    private GameObject _gameMenu;
    private float _spawnRate = 1.0f;
    private int _score;

    public bool isGameActive;

    public void StartGame(Difficulty difficulty)
    {
        isGameActive = true;
        _score = 0;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        _spawnRate /= (int)difficulty;
        _gameMenu.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, _targets.Count);
            Instantiate(_targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        _restartButton.gameObject.SetActive(true);
        _gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}