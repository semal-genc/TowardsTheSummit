using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class yonetici : MonoBehaviour
{
    public Text skor;
    public static float skorSayisi = 0;
    public Text countdownText;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) // Eðer baþlangýç sahnesindeyse
        {
            skorSayisi = 0;
        }

        // Geri sayýmýn baþladýðýný doðrulama
        if (countdownText != null)
        {
            StartCoroutine(Countdown());
        }
        else
        {
            Debug.LogError("countdownText referansý atanmadý!");
        }
    }

    void Update()
    {
        // Geri sayým metni görünüyorsa zamaný durdur
        if (countdownText != null && countdownText.gameObject.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        // Skor güncellenmesi
        if (skor != null)
        {
            skor.text = skorSayisi.ToString();
        }

        // High score güncellemesi
        if (skorSayisi > PlayerPrefs.GetFloat("highScore"))
        {
            PlayerPrefs.SetFloat("highScore", skorSayisi);
        }
    }

    IEnumerator Countdown()
    {
        int countdownTime = 3;

        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            Debug.Log("Geri sayým: " + countdownTime);
            yield return new WaitForSecondsRealtime(1); // Gerçek zamanla geri sayým
            countdownTime--;
        }

        countdownText.text = "Start!";
        yield return new WaitForSecondsRealtime(1);

        countdownText.gameObject.SetActive(false); // Geri sayým metnini gizle
    }
}
