using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeminControl : MonoBehaviour
{
    public float ZıplamaKuvveti;
    public bool zemineTemasEdildi;
    float rastgeleDeger;

    private void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 zıplamaVelocity = rb.velocity;
                zıplamaVelocity.y = ZıplamaKuvveti;
                rb.velocity = zıplamaVelocity;

                if (zemineTemasEdildi == false) 
                {
                    rastgeleDeger = Random.Range(1, 6);
                    yonetici.skorSayisi += rastgeleDeger;
                    zemineTemasEdildi = true;
                }
                Destroy(gameObject, 1.30f);
            }
        }       
    }
}
