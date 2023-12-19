using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yonetici : MonoBehaviour
{
    public Text skor;
    public static float skorSayisi = 0;

    void Update()
    {
        skor.text = skorSayisi.ToString();

        if (skorSayisi > PlayerPrefs.GetFloat("highScore"))
        {
            PlayerPrefs.SetFloat("highScore", skorSayisi);
        }
    }
}
