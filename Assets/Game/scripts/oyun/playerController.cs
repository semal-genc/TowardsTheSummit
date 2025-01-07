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
    public float fallThreshold = -8.0f;

    void Update()
    {

        float rotationZ = Input.acceleration.x * 90; // Telefonun yatay eksen etkileþimi
        bool moveRight = false;
        bool moveLeft = false;

        if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
        }

        // Telefon saða döndürüldü veya sað tuþa basýldý
        if (rotationZ > rotationThreshold || moveRight)
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
        // Telefon sola döndürüldü veya sol tuþa basýldý
        else if (rotationZ < -rotationThreshold || moveLeft)
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

        // Ölüm durumunu kontrol et
        if (transform.position.y < fallThreshold && !isTouchingGround)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(2);
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