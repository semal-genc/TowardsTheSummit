using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text yourScore;
    [SerializeField] Text highScore;

    private void Start()
    {
        ScoreDisplay();
        HighScoreDisplay();
    }

    private void ScoreDisplay()
    {
        yourScore.text = yonetici.skorSayisi.ToString();
    }

    private void HighScoreDisplay()
    {
        highScore.text = PlayerPrefs.GetFloat("highScore").ToString();

    }

}
