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
        if (SceneManager.GetActiveScene().buildIndex == 1) // E�er ba�lang�� sahnesindeyse
        {
            skorSayisi = 0;
        }

        // Geri say�m�n ba�lad���n� do�rulama
        if (countdownText != null)
        {
            StartCoroutine(Countdown());
        }
        else
        {
            Debug.LogError("countdownText referans� atanmad�!");
        }
    }

    void Update()
    {
        // Geri say�m metni g�r�n�yorsa zaman� durdur
        if (countdownText != null && countdownText.gameObject.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        // Skor g�ncellenmesi
        if (skor != null)
        {
            skor.text = skorSayisi.ToString();
        }

        // High score g�ncellemesi
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
            Debug.Log("Geri say�m: " + countdownTime);
            yield return new WaitForSecondsRealtime(1); // Ger�ek zamanla geri say�m
            countdownTime--;
        }

        countdownText.text = "Start!";
        yield return new WaitForSecondsRealtime(1);

        countdownText.gameObject.SetActive(false); // Geri say�m metnini gizle
    }
}
