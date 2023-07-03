using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private int playerDeaths;
    private int enemiesKilled;
    private int highScore;

    public Text _playerDeaths;
    public Text _enemiesKilled;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayerLostLife()
    {
        playerDeaths = int.Parse(_playerDeaths.text) + 1;
        _playerDeaths.text = playerDeaths.ToString();

        if (playerDeaths >= 3)
        {
            UpdateHighScore();
            SceneManager.LoadScene("Game Over");
        }
    }

    public void EnemyKilled()
    {
        enemiesKilled = int.Parse(_enemiesKilled.text) + 1;
        _enemiesKilled.text = enemiesKilled.ToString();
    }

    void UpdateHighScore()
    {
        if (enemiesKilled > highScore)
        {
            highScore = enemiesKilled;
        }
    }

    public int GetEnemiesKilled()
    {
        return enemiesKilled;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void ResetValues()
    {
        playerDeaths = 0;
        enemiesKilled = 0;
        _playerDeaths.text = "0";
        _enemiesKilled.text = "0";
    }
}

