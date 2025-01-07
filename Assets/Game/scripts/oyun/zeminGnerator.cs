using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeminGnerator : MonoBehaviour
{
    public GameObject zemin;
    private Transform tr;
    public int zeminSayisi;
    public float zeminGenislik;
    public float minY, maxY;

    private void Start()
    {
        tr = zemin.GetComponent<Transform>();
        Vector3 spawnKonumu = new Vector3();
        Vector2 yeniScale = new Vector2();

        for (int i = 0; i < zeminSayisi; i++)
        {
            yeniScale.x = Random.Range(0.5f, 1f);
            yeniScale.y = Random.Range(0.8f, 1f);
            tr.localScale = yeniScale;

            spawnKonumu.y += Random.Range(minY, maxY);
            spawnKonumu.x = Random.Range(-zeminGenislik, zeminGenislik);

            Instantiate(zemin, spawnKonumu, Quaternion.identity);
        }
    }
}