using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text myText;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            Vector2 touchPositionInCanvas = Camera.main.ScreenToWorldPoint(touchPosition);
            if (RectTransformUtility.RectangleContainsScreenPoint(myText.rectTransform, touchPositionInCanvas))
            {
                SceneManager.LoadScene(1);
            }
        }
        
    }
}
