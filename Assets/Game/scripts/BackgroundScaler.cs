using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        mainCamera = Camera.main; // Ana kamera referansý al
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer'ý al
        AdjustBackgroundScale(); // Baþlangýçta arka plan ölçeðini ayarla
    }

    void Update()
    {
        // Ekran boyutu deðiþtiðinde arka planýn ölçeðini yeniden ayarla
        AdjustBackgroundScale();
    }

    void AdjustBackgroundScale()
    {
        // Ekran çözünürlüðünü al
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Kamera çözünürlüðü ile uyumlu olacak þekilde arka planýn ölçeðini ayarla
        float aspectRatio = (float)screenWidth / screenHeight;

        // Kamera çözünürlüðü ile uyumlu sprite boyutunu hesapla
        float cameraHeight = mainCamera.orthographicSize * 2; // Kamera yüksekliði
        float cameraWidth = cameraHeight * aspectRatio; // Kamera geniþliði

        // Sprite'ýn boyutlarýný al
        float spriteWidth = spriteRenderer.sprite.bounds.size.x;
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;

        // Ekraný tamamen kaplayacak þekilde sprite ölçeklendir
        float scaleWidth = cameraWidth / spriteWidth;
        float scaleHeight = cameraHeight / spriteHeight;

        // En uygun ölçek oranýný seç
        float scale = Mathf.Max(scaleWidth, scaleHeight); // Hem geniþliði hem de yüksekliði kapsayacak þekilde

        // Yeni ölçeði uygula
        transform.localScale = new Vector3(scale, scale, 1);

        // Arka planýn pozisyonunu sýfýrla, böylece ekranýn tam ortasýnda olur
        transform.position = new Vector3(0, 0, transform.position.z);
    }
}
