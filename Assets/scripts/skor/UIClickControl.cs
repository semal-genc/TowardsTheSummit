using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIClickControl : MonoBehaviour
{
    public Text menu;
    public Text play;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            Vector2 touchPositionInCanvas = Camera.main.ScreenToWorldPoint(touchPosition);
            if (RectTransformUtility.RectangleContainsScreenPoint(menu.rectTransform, touchPositionInCanvas))
            {
                SceneManager.LoadScene(0);
                yonetici.skorSayisi = 0;
            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            Vector2 touchPositionInCanvas = Camera.main.ScreenToWorldPoint(touchPosition);
            if (RectTransformUtility.RectangleContainsScreenPoint(play.rectTransform, touchPositionInCanvas))
            {
                SceneManager.LoadScene(1);
                yonetici.skorSayisi = 0;
            }
        }

    }
}
