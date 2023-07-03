using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public Text _scoreText;
    public Text _highScoreText;

    void Start()
    {
        _scoreText.text = "Enemigos eliminados: " + GameController.Instance.GetEnemiesKilled().ToString();

        _highScoreText.text = "Puntaje más alto: " + GameController.Instance.GetHighScore().ToString();

        GameController.Instance.ResetValues();
    }
}
