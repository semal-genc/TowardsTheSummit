using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIClickControl : MonoBehaviour
{
    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene(0);
        yonetici.skorSayisi = 0;
    }

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene(1);
        yonetici.skorSayisi = 0;
    }
}
