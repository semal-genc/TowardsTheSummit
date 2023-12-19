using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float minX = -2.4f;
    public float maxX = 2.4f;
    private float rotationThreshold = 10.0f;
    private bool isTouchingGround;
    private float timer;

    void Update()
    {

        float rotationZ = Input.acceleration.x * 90; // Telefonun yatay eksen etkileþimi
        if (Mathf.Abs(rotationZ) > rotationThreshold)
        {
            // Telefon saða döndürüldü
            if (rotationZ > 0)
            {
                // X ekseni sýnýrlarýný kontrol et
                if (transform.position.x < maxX)
                {
                    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                }
                else
                {
                    // Ekranýn sað kenarýndan çýktýðýnda, sol kenardan tekrar gir
                    transform.position = new Vector3(minX, transform.position.y, transform.position.z);
                }
            }
            // Telefon sola döndürüldü
            else
            {
                // X ekseni sýnýrlarýný kontrol et
                if (transform.position.x > minX)
                {
                    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                }
                else
                {
                    // Ekranýn sol kenarýndan çýktýðýnda, sað kenardan tekrar gir
                    transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
                }
            }
        }
        PlayerDestroy();
    }

    private void PlayerDestroy()
    {
        if (isTouchingGround)
        {
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= 10f)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingGround = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingGround = false;
        }
    }
}






