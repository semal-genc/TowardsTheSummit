using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
